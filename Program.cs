using System;

class Profile {
    public ConsoleColor color;
}

class User {
   public string userName;
   public string password;
   public Profile profile;

   public User(string userName, string password, ConsoleColor color = ConsoleColor.White) {
    this.userName = userName;
    this.password = password;
    this.profile = new Profile();
    this.profile.color = color;
   }
}

namespace TerminalProfiles {
    class Program {
        // Stores our users. List is like Array but it has some features
        // that make it easier to work with
        private List<User> users;
        
        // The current logged in user 
        private User user;

        // This is a 'constant' – a fixed value that I use this in a few
        // places in the program so I don't want to keep typing out 
        // new User("Guest"... etc everytime! Plus if I want to change it
        // I only have to change it in one place.
        User DEFAULT_USER = new User("Guest", "", ConsoleColor.Green);

        // This method is the constructor, you can tell cos it has the same
        // name as the class. It is called once and only once, when a new
        // instance of the class is created (e.g., new Program())
        // Its job is to do any set up that the class may need – in this case
        // it just sets the fields above like the list of users and the default
        // user.
        public Program() {
            this.user = DEFAULT_USER;
            this.users = new List<User>() {
                new User("Brendan", "1234", ConsoleColor.DarkCyan),
                new User("Josh", "abcd", ConsoleColor.DarkRed)
            };
        }

        static void Main(string[] args) {
            // Create a new instance of the program to work with – 
            // there may be better ways to work with this class but
            // this allows access to those fields above like user, users etc
            // without having to use static everywhere.
            Program program = new Program();

            program.PrintTitle();

            // This method calls itself at the end which works like a loop,
            // keeping the program running until you type exit.
            // A function/method that calls itself is called recursive.
            // Recursion can get very hard to understand but this example is
            // the simplest type.
            program.ParseInput();
        }

        private void ParseInput() {
            if (this.user == DEFAULT_USER) this.Login();

            Console.ForegroundColor = this.user.profile.color;

            Console.WriteLine("\r\nCommands: list, logout, exit");
            string? input = Console.ReadLine();

            // This is a switch block, handy for handling many cases.
            // Another way to write this would be:
            //
            //  if (input == "list") this.ListUsers();
            //  else if (input == "logout") this.Logout();
            //  else if (input == "exit") {
            //      Console.WriteLine("Goodbye.");
            //      return;
            //  }
            //  this.ParseInput();
            //
            // No wrong answers here, just personal preference really.
            switch (input) {
                case "list":
                    this.ListUsers();
                    break;

                case "logout":
                    this.Logout();
                    break;

                case "exit":
                    Console.WriteLine("Goodbye.");
                    return;
            }

            this.ParseInput();
        }

        private void PrintTitle() {
            Console.Clear();
            Console.ForegroundColor = this.user.profile.color;
            Console.Title = "NULL.net v0.0.1";
            Console.WriteLine("NULL.net v0.0.1");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
        }

        private void Login()
        {
            // Using Write instead of WriteLine here because WriteLine
            // adds a return/newline at the end and I wanted the login prompt
            // to be on the same line.
            Console.Write("USER: ");
            string? userName = Console.ReadLine();
            Console.Write("PASSWORD: ");
            string? password = Console.ReadLine();

            // Check both username and password at the same time.
            // Using List gives us the ability to use this handy Find method
            User? foundUser = this.users.Find(user => user.userName.ToLower() == userName?.ToLower() && user.password == password);

            if (foundUser == null) {
                Console.WriteLine("Invalid login");
                // This is also an example of recursion, if they get the login wrong,
                // run the login function again to give them another try
                this.Login();
                return;
            }

            this.user = foundUser;
            // It'd be good to only set the color in one place in the program
            // to prevent errors where we accidentally forget to set it...
            // You could make your own Write method that always checks the color
            // first then uses Console.WriteLine internally. Like this:
            //
            //  static void Write(string message ) {
            //      Console.ForegroundColor = this.user.profile.color;
            //      Console.WriteLine(message);
            //  }
            // 
            // Then use it like this:
            // 
            //  Program.Write("My message");
            //
            Console.ForegroundColor = this.user.profile.color;

            Console.WriteLine("Logged in.");
            Console.WriteLine("Welcome back, " + user.userName);
        }

        // Logging out in this program is as simple as resetting the 
        // user to the default user (guest)
        private void Logout() {
            this.user = DEFAULT_USER;
            Console.ForegroundColor = this.user.profile.color;
        }

        private void ListUsers() {
            Console.WriteLine("");
            Console.WriteLine("Users:");
            // Another example of how you can use List.
            // For each user in the users list, print out their name!
            this.users.ForEach(user => Console.WriteLine(user.userName));
        }
    }
}

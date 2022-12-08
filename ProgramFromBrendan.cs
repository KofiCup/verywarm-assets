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

        private List<User> users;
        private User user;
        User DEFAULT_USER = new User("Guest", "", ConsoleColor.Green);

        public Program() {
            this.user = DEFAULT_USER;
            this.users = new List<User>() {
                new User("Brendan", "1234", ConsoleColor.DarkCyan),
                new User("Josh", "abcd", ConsoleColor.DarkRed)
            };
        }

        static void Main(string[] args) {
            Program program = new Program();
            Console.ForegroundColor = program.user.profile.color;

            // You could load users from data.json here and store them in users array
            program.PrintTitle(program.user);
            User user = program.Login();


            program.ParseInput();
        }

        private void ParseInput() {
            if (this.user == DEFAULT_USER) this.Login();

            Console.WriteLine("\r\nCommands: list, logout, exit");
            string? input = Console.ReadLine();

            if (input == "list") this.ListUsers();
            else if (input == "logout") this.Logout();
            else if (input == "exit") {
                Console.WriteLine("Goodbye.");
                return;
            }
            this.ParseInput();
        }

        private void PrintTitle(User user) {
            Console.Clear();
            Console.Title = "NULL.net v0.0.1";
            Console.WriteLine("NULL.net v0.0.1");
            Console.WriteLine("------------------------------");
            Console.WriteLine("\r\n Hello, " + user.userName);
        }

        private User Login()
        {
            Console.Write("USER: ");
            string? userName = Console.ReadLine();
            Console.Write("PASSWORD: ");
            string? password = Console.ReadLine();

            User? foundUser = this.users.Find(user => user.userName.ToLower() == userName?.ToLower() && user.password == password);

            if (foundUser == null) {
                Console.WriteLine("Invalid login");
                return this.Login();
            }

            this.user = foundUser;
            Console.ForegroundColor = this.user.profile.color;

            Console.WriteLine("Logged in.");
            Console.WriteLine("Welcome back, " + user.userName);

            return foundUser;
        }

        private void Logout() {
            this.user = DEFAULT_USER;
            Console.ForegroundColor = this.user.profile.color;
        }

        private void ListUsers() {
            Console.WriteLine("");
            Console.WriteLine("Users:");
            this.users.ForEach(user => Console.WriteLine(user.userName));
        }
    }
}
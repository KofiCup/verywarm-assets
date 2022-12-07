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

namespace nullnetv1
{
    class Program
    {
        static User[] users = { new User("Brendan","1234"), new User("Josh", "abcd", ConsoleColor.DarkRed) };

        static void Main(string[] args)
        {
            Console.Title = "NULL.net v0.0.1";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("NULL.net v0.0.1");
            Console.WriteLine("------------------------------");

            // You could load users from data.json here and store them in users array
            LoginProgram();

        }

        static void LoginProgram()
        {
            // Landing Page
            Console.Title = "NULL.net v0.0.1";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("USER:");

            string? userName = Console.ReadLine();
            User? foundUser = Array.Find(Program.users, u => u.userName == userName);

            if (foundUser == null) {
                Console.WriteLine(userName + " not found");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("PASSWORD:");

            string? password = Console.ReadLine();

            //User Identification
            if (foundUser.password != password) {}
                Console.WriteLine("------------");
                Console.WriteLine("USER AUTHENTICATION ERROR");
                Console.WriteLine("Incorrect Passcode Input");
                Console.WriteLine("");
                Console.WriteLine("Press any key to restart shell");
                Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine("----------------------");     

                LoginProgram();
            }

           else
            {
                Console.WriteLine("Logged in. Hello " + foundUser.userName);
                Console.WriteLine("");
                Console.WriteLine("----");
                Menu(foundUser.profile);
        
            }

            else
            {
                if (userName != null && userName.ToLower() == "guest")
                {
                    Console.WriteLine("Loading Blank Guest Profile\n \n");

                    GuestMenu();
                }
                else
                {
                  //No user data
                    Console.WriteLine("------------");
                    Console.WriteLine("USER IDENTIFICATION ERROR:");
                    Console.WriteLine("Non-Alpha Profile Detected");
                    Console.WriteLine("");
                    Console.WriteLine("If you dont have a profile, you can log on as a guest\n");
                    Console.WriteLine("Press any key to restart shell");
                    Console.ReadKey();
                    Console.WriteLine("");
                    Console.WriteLine("----------------------");

                    LoginProgram();                    
                }
            }

            Console.ReadKey();
        }

        static void Menu(Profile profile)
        {
            Console.ForegroundColor = profile.color != null ? profile.color : ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("         USER ID: KofiiCup");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("            Welcome Kofi");
            Console.WriteLine("");
            Console.WriteLine("\n  Please choose an application:\n------------------------------------\n \n  STTS   PRJCTS   CLCLTR   EXIT");
            Console.WriteLine("\n------------------------------------\n");

            string UserDirectory = Console.ReadLine();

            if (UserDirectory == "EXIT")
            {
                profileSuspention();
            }

        }

        static void GuestMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("         USER ID: Guest");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("            Welcome User");
            Console.WriteLine("");
            Console.WriteLine("\n  Please choose an application:\n------------------------------------\n \n  INFO   EXIT");
            Console.WriteLine("\n------------------------------------\n");

            guestNav();
        }

        static void guestNav()
        {
            string UserDirectory = Console.ReadLine();

            if (UserDirectory == "EXIT")
            {
                profileSuspention();
            }
            else
            {
                if (UserDirectory == "INFO")
                {
                    guestInfo();
                }
                else
                {
                    Console.WriteLine("\nInvalid Application Name -- Please choose from the above\n");

                    guestNav();
                
                }
            }
        }

        static void profileSuspention()
        {
                Console.WriteLine("\nAre you sure you want to exit the current profile?\nY = Yes -- N = No");
                string exitFunction = Console.ReadLine();

                if (exitFunction == "Y")
                {
                    Console.WriteLine("\nSuspending profile...");
                    Console.WriteLine("\n------------------------------------\n");

                    LoginProgram();
                }

                else
                {
                    if (exitFunction == "N")
                    {
                        Console.WriteLine("Canceling Profile Suspension...\nRebooting profile to 'Guest'...\n------------------------------------\n");

                        GuestMenu();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Responce\nPlease type either the 'Y' key or the 'N' key.\n------------------------------------\n");

                        profileSuspention();
                    }
                }
            
        }

        static void guestInfo ()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("\n            GUEST INFO");
            Console.WriteLine("\n------------------------------------");
        }
    }
}

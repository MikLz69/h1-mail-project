using System;

namespace Program{
    public class Program {
        public static void Main(string[] args) {
            var program = new Program();
            var commands = new string[]
            {
                "mail info: prints user information",
                "mail inbox: prints mail inbox",
                "mail view <mail>: view a specific mail",
                "mail send: create and send your own mail"
            };
            var inbox = new List<string>() {
            };
            Console.WriteLine("Welcome to the mail, type `mail help` for available commands");
            program.runProgram(commands, inbox);
            
        }
            public void runProgram(string[] commands, List<string> inbox) {
            var command = Console.ReadLine();
            command = command?.ToLower();

            if (command == "mail help") {
                for (int i = 0; i < commands.Length; i++)
                    Console.WriteLine(commands[i]);
            }
            else if (command == "mail inbox") {
                if (inbox.Count == 0) 
                    Console.WriteLine("You have no mail");
                else {
                    Console.WriteLine("not implemented");
                }
            }
            else if (command == "mail view title") {
                Console.WriteLine("not implemented");
            }
            else if (command == "mail send") {
                Console.WriteLine("Enter user: ");
                var mailReciever = Console.ReadLine();
                Console.WriteLine("Enter title: ");
                var mailTitle = Console.ReadLine();
                Console.WriteLine("Enter bodytext: ");
                var mailBody = Console.ReadLine();
                Console.WriteLine(mailReciever + " " + mailTitle + " " + mailBody);
            }
            runProgram(commands, inbox);
        }
    }
}

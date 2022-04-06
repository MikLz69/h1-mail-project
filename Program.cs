using System;
using System.Text.Json;

namespace Program{

    public class Mail {
        public string? title {get; set; }
        public string? content {get; set; }
        public int? id { get; set; }
        public string? sender { get; set; }
    }

    public class ServerClient {
        private readonly HttpClient client;
        public ServerClient() {
            client = new HttpClient();
        }

        public async Task<Mail> Read() {
            var json = await client.GetStringAsync("http://localhost:8000/read?user=Mikkel&number=1") ;
            var mail = JsonSerializer.Deserialize<Mail>(json);
            if (mail == null)
                throw new Exception();
            return mail;
        }
    }
    public class Program {
        public static ServerClient? sc;
        public static void Main(string[] args) {
            sc = new ServerClient();
            var program = new Program();
            string user = "Mikkel";
            var commands = new string[]
            {
                "mail info: prints user information",
                "mail inbox: prints mail inbox",
                "mail read <mail number>: view a specific mail",
                "mail send: create and send your own mail"
            };
            var inbox = new List<string>() {
            };
            Console.WriteLine("Welcome to the mail, type `mail help` for available commands");
            program.runProgram(commands, inbox, user);
            for (;;);
        }
            public async void runProgram(string[] commands, List<string> inbox, string user) {
            if (sc == null)
                throw new NullReferenceException();
            Console.WriteLine(await sc.Read());
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
            else if (command == "mail read 1" ) {
                Console.WriteLine("not implemented");
            }
            else if (command == "mail send") {
                Console.WriteLine("Enter user: ");
                var mailReciever = Console.ReadLine();
                Console.WriteLine("Enter title: ");
                var mailTitle = Console.ReadLine();
                Console.WriteLine("Enter bodytext: ");
                var mailBody = Console.ReadLine();
                Console.WriteLine(mailReciever + " " + mailTitle + " " + mailBody + " " + user);
            }
            runProgram(commands, inbox, user);
        }
    }
}

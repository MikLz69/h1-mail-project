using System;
using System.Text.Json;
using System.Text;

namespace Program{

    public class Mail {
        public string? title {get; set; }
        public string? content {get; set; }
        public int? id { get; set; }
        public string? sender { get; set; }
    }
    public class InboxEntry {
        public string? title {get; set; }
        public string? sender { get; set; }
    }
    public class Res {
        public string? msg {get; set; }
    }

    public class SendReq {
        public string? fromUser {get; set;}
        public string? toUser {get; set;}
        public Mail? mail {get; set;}
        }

    public class ServerClient {
        private readonly HttpClient client;
        public ServerClient() {
            client = new HttpClient();
        }
        public async Task<InboxEntry[]> Inbox() {
            var json = await client.GetStringAsync("http://localhost:8000/inbox?user=Mikkel") ;
            var inboxEntry = JsonSerializer.Deserialize<InboxEntry[]>(json);
            if (inboxEntry == null)
                throw new Exception();
            return inboxEntry;
        }
        public async Task<Mail> Read() {
            var json = await client.GetStringAsync("http://localhost:8000/read?user=Mikkel&number=1") ;
            var mail = JsonSerializer.Deserialize<Mail>(json);
            if (mail == null)
                throw new Exception();
            return mail;
        }
        
        public async Task<Res> Send(SendReq data) {
            var contentJson = JsonSerializer.Serialize<SendReq>(data);
            var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("http://localhost:8000/send", content) ;
            if (res == null || res.Content == null)
                throw new Exception();
            var msg = JsonSerializer.Deserialize<Res>(res.Content.ToString()!);
            if (msg == null)
                throw new Exception();
            return msg;
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
            Console.WriteLine(await sc.Inbox());
            Console.WriteLine(await sc.Send(new SendReq(){fromUser = "Theis", toUser = "Mikkel", mail = new Mail(){title = "doing your mom", content = "i ma doing you mom right now", id = 0, sender = "Theis"}}));
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

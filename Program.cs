using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string[] commands = new string[]
            {
                "mail info: prints user information",
                "mail inbox: prints mail inbox",
                "mail view <mail>: view a specific mail",
                "mail send: create and send your own mail"
            };
            string command = Console.ReadLine()
            if command.ToLower() = "mail help" {
                for (int i = 0; i < commands.Length; i++)
                    Console.WriteLine(commands[i] + "\n")
            }
            
        }
    }
}

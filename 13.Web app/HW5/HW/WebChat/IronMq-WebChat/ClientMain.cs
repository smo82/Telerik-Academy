using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.iron.ironmq;
using io.iron.ironmq.Data;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace IronMq_WebChat
{
    class ClientMain
    {
        static bool turnOfOwnMessages = false;

        static void Main(string[] args)
        {
            Client client = new Client(
                "521112115ac50e0009000006",
                "rLDdf7E3hW06jxS-DuOfY6gTFLU");
            Queue queue = client.queue("WebApi-HwChat");

            string machineIp = GetLocalIp();

            Console.WriteLine("Welcome to the Web Api Homework channel");
            Console.WriteLine("Please enter your message.");
            Console.WriteLine("For exit enter \"exit\"");
            Console.WriteLine("To stop showing your own messages enter \"mine-off\" / \"mine-on\"");
            Console.Write(">");

            Thread listenning = new Thread(delegate()
            {
                ReadQueueMessages(queue, machineIp);
            });
            listenning.Start();

            string newMessage = Console.ReadLine();
            string newMessageToLower = newMessage.ToLower();
            string messageDetails;
            while (newMessageToLower != "exit")
            {
                if (newMessageToLower == "mine-off")
                {
                    turnOfOwnMessages = true;
                    Console.WriteLine("Your own messages will no-longer be displayed!");
                }
                else if (newMessageToLower == "mine-on")
                {
                    turnOfOwnMessages = false;
                    Console.WriteLine("Your own messages will be displayed also!");
                }
                else
                {
                    messageDetails = GetMessageDetails(newMessage, machineIp);
                    queue.push(messageDetails);
                }

                newMessage = Console.ReadLine();
                newMessageToLower = newMessage.ToLower();
            }

            listenning.Abort();
        }

        private static void ReadQueueMessages(Queue queue, string machineIp)
        {
            while (true)
            {
                Message msg = queue.get();
                if (msg != null)
                {
                    MessageDetails recievedMessage = JsonConvert.DeserializeObject<MessageDetails>(msg.Body);
                    if ((turnOfOwnMessages && recievedMessage.Ip != machineIp) || !turnOfOwnMessages)
                    {
                        Console.WriteLine("Received Message (IP:{0}) -> '{1}'", recievedMessage.Ip, recievedMessage.Message);
                    }

                    queue.deleteMessage(msg);
                }
                Thread.Sleep(100);
            }
        }

        private static string GetMessageDetails(string message, string machineIp)
        {
            MessageDetails messageDetails = new MessageDetails()
            {
                Ip = machineIp,
                Message = message
            };

            return JsonConvert.SerializeObject(messageDetails);
        }

        private static string GetLocalIp()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }
    }
}

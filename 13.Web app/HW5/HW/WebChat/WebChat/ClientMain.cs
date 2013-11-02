using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebChat
{
    class ClientMain
    {
        static void Main(string[] args)
        {
            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-ed80e48c-24dd-4955-958b-7eecd8de0600",               // PUBLISH_KEY
                "sub-c-8f7881d6-082b-11e3-ab8d-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-ZGJiMThiNTAtMDljOC00MzY4LWE4OTAtZWZlZTQ0YjIwYzZi",   // SECRET_KEY
                true                                                        // SSL_ON?
            );
            string channel = "hw-chat-channel";

            string machineIp = GetLocalIp();

            Console.WriteLine("Welcome to the Web Api Homework channel");
            Console.WriteLine("Please enter your message.");
            Console.WriteLine("For exit enter \"exit\"");
            Console.WriteLine("To stop showing your own messages enter \"mine-off\" / \"mine-on\"");
            Console.Write(">");

            bool turnOfOwnMessages = false;

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate(object message)
                    {
                        MessageDetails recievedMessage = JsonConvert.DeserializeObject<MessageDetails>(message.ToString());
                        if ((turnOfOwnMessages && recievedMessage.Ip != machineIp) || !turnOfOwnMessages)
                        {
                            Console.WriteLine("Received Message (IP:{0}) -> '{1}'", recievedMessage.Ip, recievedMessage.Message);
                        }
                        return true;
                    }
                )
            );
            t.Start();
            
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
                    pubnub.Publish(channel, messageDetails);
                }
                newMessage = Console.ReadLine();
                newMessageToLower = newMessage.ToLower();
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

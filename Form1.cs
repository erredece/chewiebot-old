using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace ChewieBot
{
    public partial class chewieBot : Form

    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;

        string userName, password, channelName, chatCommandId, chatMessagePrefix, chatPingId;
        DateTime lastMessage;
        Queue<string> sendMessageQueue;

        public chewieBot()
        {
            var parameters = File
            .ReadAllLines("parameters.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            this.userName = parameters["username"];
            this.password = parameters["password"];
            this.channelName = parameters["channel"];
            chatCommandId = "PRIVMSG";
            chatPingId = "PING";
            chatMessagePrefix = $":{userName}|{userName}@{userName}.tmi.twitch.tv {chatCommandId} #{channelName} :";
            sendMessageQueue = new Queue<string>(); 
            InitializeComponent();
            Reconnect();

        }

        private void Reconnect()
        {
            tcpClient = new TcpClient("irc.chat.twitch.tv", 6667);
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());
            writer.WriteLine("PASS " + password + Environment.NewLine 
                + "NICK " + userName + Environment.NewLine 
                + "USER " + userName + " 8 :" + userName);
            writer.Flush();
            writer.WriteLine("JOIN #" + channelName);
            writer.Flush();
            lastMessage = DateTime.Now;
        }

        void timer1_Tick(object sender, EventArgs e) {
            if (!tcpClient.Connected)
            {
                Reconnect();
            }

            trySendMessage();
            tryReceiveMessage();
            void trySendMessage()
            {
                if (DateTime.Now - lastMessage > TimeSpan.FromSeconds(2))
                {
                    if (sendMessageQueue.Count > 0)
                    {
                        var message = sendMessageQueue.Dequeue();
                        writer.WriteLine($"{chatMessagePrefix}{message}");
                        writer.Flush();
                        lastMessage = DateTime.Now;
                    }
                }
            }

        void tryReceiveMessage()
            {
                if (tcpClient.Available > 0 || reader.Peek() >= 0)
                {
                    var message = reader.ReadLine();
                    Console.WriteLine(message);
                    var iCollon = message.IndexOf(":", 1);
                    if (iCollon > 0)
                    {
                        var command = message.Substring(1, iCollon);
                        if (command.Contains(chatCommandId))
                        {
                            var iBang = command.IndexOf("!");
                            if (iBang > 0)
                            {
                                var speaker = command.Substring(0, iBang);
                                var chatMessage = message.Substring(iCollon + 1);

                                receiveMessage(speaker, chatMessage);
                            }
                        }

                    }
                    if (message.Contains(chatPingId))
                    {
                        writer.WriteLine("PONG :tmi.twitch.tv");
                        lastMessage = DateTime.Now;
                    }
                }
            }
        }

        void receiveMessage(string speaker, string message)
        {
            chatText.Text += $"\r\n{speaker}: {message}";

            if (message.StartsWith("!erretest"))
            {
                sendMessage($"I, errebot, am alive, {speaker}! MrDestructoid");
            }
        }

        void sendMessage(string message)
        {
            sendMessageQueue.Enqueue(message);
        }
        
        private void ChewieBot_Load(object sender, EventArgs e)
        {

        }
    }       
}

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
using TwitchLib;
using TwitchLib.Models.Client;
using TwitchLib.Events.Client;
using TwitchLib.Models.API.v5.Users;

namespace ChewieBot
{
    public partial class chewieBot
    {
        readonly ConnectionCredentials credentials = new ConnectionCredentials(twitchInfo.botUsername, twitchInfo.authToken);
        TwitchClient client;

                private void ChewieBot_Load(object sender, EventArgs e)
                {

                }

        internal void Connect()
        {
            Console.WriteLine("Connecting...");

            client = new TwitchClient(credentials, twitchInfo.channelname, logging: true);

            client.ChatThrottler = new TwitchLib.Services.MessageThrottler(10, TimeSpan.FromSeconds(30));
            client.WhisperThrottler = new TwitchLib.Services.MessageThrottler(10, TimeSpan.FromSeconds(30));


            client.OnLog += Client_OnLog;
            client.OnConnectionError += Client_OnConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;

            client.Connect();

            TwitchAPI.Settings.ClientId = twitchInfo.clientID;
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if(e.ChatMessage.Message.StartsWith("!erretest", StringComparison.InvariantCultureIgnoreCase))
            {
                client.SendMessage($"I am alive thanks to my song, {e.ChatMessage.DisplayName} MrDestructoid");

            }
        }

        //private TimeSpan? GetUptime()
        //{

        //    string userId = GetUserId(twitchInfo.channelname);
        //    if(userId == null)
        //    {
        //        return null;
        //    }

        //    return TwitchAPI.Streams.v5.GetUptime(userId).Result;

        //}

        //string GetUserId(string username)
        //{
        //    User[] userList = TwitchAPI.Users.v5.GetUserByName(username).Result.Matches;
        //    if(userList == null || userList.Length == 0)
        //    {
        //        return null;
        //    }
        //    return userList[0].Id;
        //}

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            //Console.WriteLine(e.Data);
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Error!! {e.Error}");
        }

            internal void Disconnect()
        {
            Console.WriteLine("Disconnecting...");
        }
    }
};
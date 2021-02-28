using System;
using IrcDotNet;

namespace IrcBot
{
    class Program
    {
        static StandardIrcClient irc = new StandardIrcClient();

        static Boolean response_sent = false;

        static void Main(string[] args)
        {

            IrcRegistrationInfo info = new IrcUserRegistrationInfo()
            {
                NickName = "myBot",
                UserName = "myBot",
                RealName = "myBot"
            };

            //Open IRC client connection
            
            irc.Connected += Irc_Connected;
            irc.RawMessageReceived += IrcClient_Receive;
            irc.MotdReceived += Irc_MotdReceived;
            

            irc.Connect("irc.SUPERSERVER.org", 6667, false, info);

            String cmd = "";

            while (cmd != "/exit")
            {
                cmd = Console.ReadLine();
                irc.SendRawMessage(cmd);
            }
        }

        private static void Irc_MotdReceived(object sender, EventArgs e)
        {
            irc.Channels.Join("#datchannel");
            irc.SendRawMessage("PRIVMSG 20100dbg salut");
        }

        private static void Irc_Connected(object sender, EventArgs e)
        {

        }

        private static void IrcClient_Receive(object sender, IrcRawMessageEventArgs e)
        {
            String str = e.RawContent;
            Console.WriteLine(str);

        }

    }
}

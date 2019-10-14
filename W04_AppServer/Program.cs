using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace W04_AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 6969;
            ChannelServices.RegisterChannel(new TcpChannel(port), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(VideoBUS), "xxx", WellKnownObjectMode.SingleCall);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            Console.WriteLine("Server is on port " + port);
            Console.ReadLine();
        }
    }
}
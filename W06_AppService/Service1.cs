using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace W06_AppService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(6969), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(VideoBUS), "xxx", WellKnownObjectMode.SingleCall);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
        }

        protected override void OnStop()
        {
        }

        /* After setting up 4 properties of serviceInstaller, install the app service via cmd
         * 
         * > cd "C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
         *
         * to install:
         * > installUtil.exe -i "D:\pvh\HSU\191A\Software Architecture\SoftwareArchitectureProject\W06_AppService\bin\Debug\W06_AppService.exe"
         *
         * to uninstall:
         *> installUtil.exe -u "D:\pvh\HSU\191A\Software Architecture\SoftwareArchitectureProject\W06_AppService\bin\Debug\W06_AppService.exe"
         */
    }
}
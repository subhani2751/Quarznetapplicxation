using Quarznetapplicxation.Jobs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace windowService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostconfigration =>
            {
                hostconfigration.Service<BackgroundTimer>(s =>
                {
                    s.ConstructUsing(backgroudTimer => new BackgroundTimer());
                    s.WhenStarted(backgroudTimer => backgroudTimer.Start());
                    s.WhenStopped(backgroudTimer => backgroudTimer.Stop());
                });
                hostconfigration.RunAsLocalSystem();
                hostconfigration.StartAutomatically();

                hostconfigration.SetServiceName("BackGroudservices");
                hostconfigration.SetDisplayName("Back Groud services");
                hostconfigration.SetDescription("to run background tasks");
            });
        }
    }
}

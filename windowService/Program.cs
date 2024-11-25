using Quartz;
using Quartz.Impl;
using Quartz.Util;
using Quarznetapplicxation.Jobs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace windowService
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] line = new string[] { $"from main - {args} " + DateTime.Now };
            File.AppendAllLines(@"C:\Windows\Temp\BackgroudTimerfrom_Quartz.txt", line);
            List<IScheduler> lstScheduler = new List<IScheduler>();

            var companies = new List<string> { "CompanyA", "CompanyB", "CompanyC" };
            List<KeyValuePair<string,string>> lstKeyValuePair = new List<KeyValuePair<string, string>>() 
                                                {   
                                                    new KeyValuePair<string, string>("CompanyA", "ForQuartz"), 
                                                    new KeyValuePair<string, string>("CompanyB", "ForQuartz1"), 
                                                };
            foreach (var item in lstKeyValuePair)
            {
                NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type" , "json" },
                { "quartz.scheduler.instanceName", "MyScheduler" },
                { "quartz.scheduler.instanceId", "AUTO" },
                { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz" },
                { "quartz.jobStore.dataSource", $"{item.Value}" },
                { "quartz.jobStore.tablePrefix", "QRTZ_" },
                { "quartz.dataSource.ForQuartz.connectionString", $"Server=DESKTOP-J6SDVUR;Database={item.Value};User Id=sa;Password=focus" },
                { "quartz.dataSource.ForQuartz.provider", "SqlServer" },
                { "quartz.jobStore.clustered", "false" }
            };
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory(props);
                IScheduler Scheduler = schedulerFactory.GetScheduler().Result;//.Result;
                lstScheduler.Add(Scheduler);                                                       //Scheduler.Start();
            }

            //foreach (var item in companies)
            {
                HostFactory.Run(hostconfigration =>
                {
                    hostconfigration.Service<BackgroundTimer>(s =>
                    {
                        s.ConstructUsing(backgroudTimer => new BackgroundTimer());
                        s.WhenStarted(backgroudTimer => backgroudTimer.Start(lstScheduler));
                        s.WhenStopped(backgroudTimer => backgroudTimer.Stop());
                    });
                    hostconfigration.RunAsLocalSystem();
                    hostconfigration.StartAutomatically();

                    hostconfigration.SetServiceName($"BackGroudservices");
                    hostconfigration.SetDisplayName($"Back Groud services");
                    hostconfigration.SetDescription($"to run background tasks");
                });
            }
            //HostFactory.Run(hostconfigration =>
            //{
            //    hostconfigration.Service<BackgroundTimer>(s =>
            //    {
            //        s.ConstructUsing(backgroudTimer => new BackgroundTimer());
            //        s.WhenStarted(backgroudTimer => backgroudTimer.Start());
            //        s.WhenStopped(backgroudTimer => backgroudTimer.Stop());
            //    });
            //    hostconfigration.RunAsLocalSystem();
            //    hostconfigration.StartAutomatically();

            //    hostconfigration.SetServiceName("BackGroudservices");
            //    hostconfigration.SetDisplayName("Back Groud services");
            //    hostconfigration.SetDescription("to run background tasks");
            //});


        }
    }
    //public class KeyValuePair
    //{
    //    public string Key { get; set; }
    //    public string Value { get; set; }

    //}
}

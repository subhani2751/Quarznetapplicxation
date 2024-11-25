using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;
using System.Collections.Specialized;

namespace Quarznetapplicxation.Jobs
{
    public class BackgroundTimer
    {
        private readonly Timer _timer;
        private readonly string _companyName;
        //public BackgroundTimer(string company ="")
        //{
        //    _timer = new Timer(50000) { AutoReset = true };
        //    _timer.Elapsed += timerElapsed;
        //    _companyName= company;
        //}
        //private void timerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    //string[] line = new string[] { DateTime.Now.ToString() };
        //    //File.AppendAllLines(@"C:\Windows\Temp\BackgroudTimerfrom_Quartz.txt", line);
        //    //string[]  line = new string[] { $"starting...{_companyName}+{DateTime.Now}" };
        //    //File.AppendAllLines(@"C:\Windows\Temp\BackgroudTimerfrom_Quartz.txt", line);
        //    NameValueCollection props = new NameValueCollection
        //    {
        //        { "quartz.serializer.type" , "json" },
        //        { "quartz.scheduler.instanceName", "MyScheduler" },
        //        { "quartz.scheduler.instanceId", "AUTO" },
        //        { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
        //        { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz" },
        //        { "quartz.jobStore.dataSource", "ForQuartz" },
        //        { "quartz.jobStore.tablePrefix", "QRTZ_" },
        //        { "quartz.dataSource.ForQuartz.connectionString", "Server=DESKTOP-J6SDVUR;Database=ForQuartz;User Id=sa;Password=focus" },
        //        { "quartz.dataSource.ForQuartz.provider", "SqlServer" },
        //        { "quartz.jobStore.clustered", "false" }
        //    };
        //    ISchedulerFactory schedulerFactory = new StdSchedulerFactory(props);
        //    IScheduler Scheduler = schedulerFactory.GetScheduler().Result;//.Result;
        //    Scheduler.Start();
        //}
        public void Start(List<IScheduler> lstScheduler = null)
        {
            
            _timer.Start();
            if (lstScheduler != null) { lstScheduler = new List<IScheduler>(); }
            foreach (IScheduler scheduler in lstScheduler)
            {
                scheduler.Start();
            }
            // IJobDetail job = JobBuilder.Create<Job>()
            //     .WithIdentity("sampleJob", "defaultGroup")
            //     .Build();

            // IJobDetail job2 = JobBuilder.Create<Job>()
            //    .WithIdentity("sampleJob2", "defaultGroup2")
            //    .Build();

            // Create a trigger to run every 10 seconds
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("sampleJob", "defaultGroup")
            //    .StartNow()
            //    .WithSimpleSchedule(x => x.WithIntervalInSeconds(5000).RepeatForever())
            //    .Build();

            // ITrigger trigger2 = TriggerBuilder.Create()
            //     .WithIdentity("sampleJob2", "defaultGroup2")
            //     .StartNow()
            //     .WithSimpleSchedule(x => x.WithIntervalInSeconds(1500).RepeatForever())
            //     .Build();

            // var jobkey = await Scheduler.CheckExists(job.Key);
            // if (jobkey != null && !jobkey)
            // {
            //     await Scheduler.ScheduleJob(job, trigger);
            // }

            // jobkey = await Scheduler.CheckExists(job2.Key);
            // if (jobkey != null && !jobkey)
            // {
            //     await Scheduler.ScheduleJob(job2, trigger2);
            // }
        }
        public void Stop()
        {
            string[] line = new string[] { "stoping..." };
            File.AppendAllLines(@"C:\Windows\Temp\BackgroudTimerfrom_Quartz.txt", line);
            _timer.Stop();
        }
    }
}
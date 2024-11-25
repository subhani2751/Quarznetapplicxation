using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quarznetapplicxation.Jobs;
using Topshelf;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Quartz.Impl.Matchers;

namespace Quarznetapplicxation.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            //StartQuartzScheduler();
            return View();
        }
        private void StartQuartzScheduler()
        {
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type" , "json" },
                { "quartz.scheduler.instanceName", $"MyScheduler_ForQuartz" },
                { "quartz.scheduler.instanceId", "AUTO" },
                { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz" },
                { "quartz.jobStore.dataSource", "ForQuartz" },
                { "quartz.jobStore.tablePrefix", "QRTZ_" },
                { "quartz.dataSource.ForQuartz.connectionString", "Server=DESKTOP-J6SDVUR;Database=ForQuartz;User Id=sa;Password=focus" },
                { "quartz.dataSource.ForQuartz.provider", "SqlServer" },
                { "quartz.jobStore.clustered", "false" }
            };
            //var config = SchedulerBuilder.Create();
            //ISchedulerFactory schedulerFactory = config.Build();

            // Create a scheduler factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(props);

            //Get a scheduler
            IScheduler Scheduler = schedulerFactory.GetScheduler().Result;//.Result;

            //var jobgrooups = Scheduler.GetJobGroupNames().Result;
            //var Trigger = Scheduler.GetTriggerGroupNames().Result;
            //var tigger = Scheduler.GetTrigger(new TriggerKey("sampleJob", "defaultGroup")).Result;
            //Scheduler.UnscheduleJob(tigger.Key);
            //Scheduler.DeleteJob(new JobKey("sampleJob"));

            Scheduler.UnscheduleJob(new TriggerKey("sampleJob", "defaultGroup"));
            Scheduler.DeleteJob(new JobKey("sampleJob", "defaultGroup"));
            Scheduler.UnscheduleJob(new TriggerKey("sampleJob2", "defaultGroup2"));
            Scheduler.DeleteJob(new JobKey("sampleJob2", "defaultGroup2"));

            // Define the job and tie it to the SampleJob class
            IJobDetail job = JobBuilder.Create<Job>()
                 .WithIdentity("sampleJob", "defaultGroup")
                 .Build();

            // Create a trigger to run every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("sampleJob", "defaultGroup")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(100).RepeatForever())
                .Build();

            var jobkey = Scheduler.CheckExists(job.Key);
            if (jobkey != null && !jobkey.Result)
            {
                Scheduler.ScheduleJob(job, trigger);
            }

            IJobDetail job2 = JobBuilder.Create<Job>()
           .WithIdentity("sampleJob2", "defaultGroup2")
           .Build();

            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("sampleJob2", "defaultGroup2")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(180).RepeatForever())
                .Build();
            var jobkey1 = Scheduler.CheckExists(job2.Key);
            if (jobkey1 != null && !jobkey1.Result)
            {
                Scheduler.ScheduleJob(job2, trigger2);
            }

            //Start the scheduler
            Scheduler.Start();

        }
    }
}
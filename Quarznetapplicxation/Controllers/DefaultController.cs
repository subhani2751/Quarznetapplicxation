using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quarznetapplicxation.Jobs;

namespace Quarznetapplicxation.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            StartQuartzScheduler();
            return View();
        }
        private void StartQuartzScheduler()
        {
            // Create a scheduler factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            // Get a scheduler
            IScheduler Scheduler = schedulerFactory.GetScheduler().Result;

            // Start the scheduler
            Scheduler.Start();

            // Define the job and tie it to the SampleJob class
            IJobDetail job = JobBuilder.Create<Job>()
                .WithIdentity("sampleJob", "defaultGroup")
                .Build();

            // Create a trigger to run every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("sampleJob", "defaultGroup")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
                .Build();

            Scheduler.ScheduleJob(job, trigger).Wait();
        }
    }
}
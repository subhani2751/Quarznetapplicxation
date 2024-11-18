using Quartz;
using Quartz.Impl;
using Quarznetapplicxation.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quarznetapplicxation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // Start Quartz Scheduler
            //StartQuartzScheduler();
        }
        //private void StartQuartzScheduler()
        //{
        //    // Create a scheduler factory
        //    ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

        //    // Get a scheduler
        //    IScheduler Scheduler = schedulerFactory.GetScheduler().Result;

        //    // Start the scheduler
        //    Scheduler.Start();

        //    // Define the job and tie it to the SampleJob class
        //    IJobDetail job =JobBuilder.Create<Job>()
        //        .WithIdentity("sampleJob", "defaultGroup")
        //        .Build();

        //    // Create a trigger to run every 10 seconds
        //    ITrigger trigger = TriggerBuilder.Create()
        //        .WithIdentity("sampleJob", "defaultGroup")
        //        .StartNow()
        //        .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
        //        .Build();

        //    Scheduler.ScheduleJob(job, trigger).Wait();
        //}
    }
}

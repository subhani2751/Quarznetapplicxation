using Quartz;
using Quartz.Impl;
using Quarznetapplicxation.Jobs;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        //    NameValueCollection props = new NameValueCollection
        //    {
        //        { "quartz.scheduler.instanceName", "MyScheduler" },
        //        { "quartz.scheduler.instanceId", "AUTO" },
        //        { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
        //        { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.StdAdoDelegate, Quartz" },
        //        { "quartz.jobStore.dataSource", "myDS" },
        //        { "quartz.jobStore.tablePrefix", "QRTZ_" },
        //        { "quartz.dataSource.myDS.connectionString", "Server = DESKTOP - J6SDVUR; Database = ForQuartz; User Id = sa; Password = focus" },
        //        { "quartz.dataSource.myDS.provider", "MySql" }
        //    };

        //    // Create a scheduler factory
        //    ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

        //    // Get a scheduler
        //    IScheduler Scheduler = schedulerFactory.GetScheduler().Result;

        //    // Start the scheduler
        //    Scheduler.Start();

        //    // Define the job and tie it to the SampleJob class

        //}
    }
}

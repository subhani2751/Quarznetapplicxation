using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Quarznetapplicxation.Jobs
{
    public class Job : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"SampleJob executed at {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
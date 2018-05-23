using Integratie.BL.Managers;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Scheduler
{
    public class Program
    {
        private static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            RunProgramRunExample().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

        private static async Task RunProgramRunExample()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<UpdateJob>()
                    .WithIdentity("job1", "group1")
                    .Build();
                IJobDetail job2 = JobBuilder.Create<ReviewJob>()
                    .WithIdentity("job2", "group2")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2,0))
                    .Build();
                ITrigger trigger2 = TriggerBuilder.Create()
                    .WithIdentity("trigger2", "group2")
                    .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(DayOfWeek.Monday, 3, 0))
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);
                await scheduler.ScheduleJob(job2, trigger2);
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
       
        // simple log provider to get something to the console
        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, string value)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class UpdateJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            DateTime date = DateTime.Now;
            FeedManager feedManager = new FeedManager();
            AlertManager alertManager = new AlertManager();
            await feedManager.UpdateFeeds(date);
            await Console.Out.WriteLineAsync("Feeds Updated");
            await alertManager.CheckAlerts(date);
            await Console.Out.WriteLineAsync("Alerts Updated");
        }
    }

    public class ReviewJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            DateTime date = DateTime.Now;
            SubjectManager subjectManager = new SubjectManager();
            AlertManager alertManager = new AlertManager();
            await subjectManager.WeeklyReview(date);
            await alertManager.ShowUserWeeklyAlerts();
            await Console.Out.WriteLineAsync("Weekly Review Updated");
        }
    }
}

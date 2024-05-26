using HangfireExample.Interfaces;

namespace HangfireExample.Services
{
    public class JobService : IJobService
    {
        public void FireAndForgetJob()
        {  
            Console.WriteLine("Fire and Forget job örneği");
        }
        public void ReccuringJob()
        {
            Console.WriteLine("Scheduled job örneği");
        }
        public void DelayedJob()
        {
            Console.WriteLine("Delayed job örneği");
        }
        public void ContinuationJob()
        {
            Console.WriteLine("Continuation job örneği");
        }
    }
}

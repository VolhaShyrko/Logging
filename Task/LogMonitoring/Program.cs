using System;

using LogMonitoring.LogEntities;

namespace LogMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\.Net mentoring\LoggingAndMonitoring\Task\MvcMusicStore\logs\*.csv";

            LogAnalyzer log = new LogAnalyzer();
            LogResult result = log.GetLogsData(path);

            Console.WriteLine("Info:{0}", result.InfoCount);
            Console.WriteLine("Debug:{0}", result.DebugCount);

            if (result.Errors.Count == 0)
            {
                Console.WriteLine("Error: 0");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine("{0} {1} {2}", error.Type, error.TimeStamp, error.Message);
                }
            }

            Console.ReadKey();
        }
    }
}


using System.Collections.Generic;

namespace LogMonitoring.LogEntities
{
    public class LogResult
    {
        public int InfoCount;
        public int DebugCount;
        public List<LogEntry> Errors;
    }
}

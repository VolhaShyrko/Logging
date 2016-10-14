using System;
using System.Collections.Generic;

using MSUtil;

using LogMonitoring.Enum;
using LogMonitoring.LogEntities;

namespace LogMonitoring
{
    public class LogAnalyzer
    {
        public LogResult GetLogsData(string path)
        {
            LogResult result = new LogResult
                                   {
                                       InfoCount = this.GetLogEntryCount(path, LogEntryLevel.Info),
                                       DebugCount = this.GetLogEntryCount(path, LogEntryLevel.Debug),
                                       Errors = this.GetLogDetails(path, LogEntryLevel.Error)
                                   };

            return result;
        }

        private int GetLogEntryCount(string path, LogEntryLevel level)
        {
            LogQueryClass logQuery = new LogQueryClass();
            COMCSVInputContextClass inputFormat = new COMCSVInputContextClass();

            String infoQuery = string.Format("SELECT count(*) FROM '{0}' WHERE level = '{1}'", path, level);

            ILogRecordset infoResults = logQuery.Execute(infoQuery, inputFormat);
            var record = infoResults.getRecord();
            return record.getValue(0);
        }

        private List<LogEntry> GetLogDetails(string path, LogEntryLevel level)
        {
            LogQueryClass logQuery = new LogQueryClass();
            COMCSVInputContextClass inputFormat = new COMCSVInputContextClass();

            String errorQuery = string.Format("SELECT * FROM '{0}' WHERE level = '{1}'", path, level);
            ILogRecordset errorResult = logQuery.Execute(errorQuery, inputFormat);

            List<LogEntry> result = new List<LogEntry>();

            while (!errorResult.atEnd())
            {
                var record = errorResult.getRecord();

                result.Add(new LogEntry
                {
                    Type = record.getValue(2).ToString(),
                    TimeStamp = DateTime.Parse(record.getValue(3).ToString()),
                    Message = record.getValue(4).ToString()
                });
                errorResult.moveNext();
            }

            return result;
        }
    }
}

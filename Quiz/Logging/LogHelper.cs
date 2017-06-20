using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Logging
{
   public class LogHelper
    {
        /// <summary>
		/// Logs exception to all configured listeners
		/// </summary>
		/// <param name="exception">Exception to be logged</param>
		/// <param name="eventId">Event number or identifier</param>
		/// <param name="priority">Importance of log message</param>
		public static void LogException(string logKey, Exception exception, int eventId = 1, int priority = 1)
        {
            //Generate a new error id
            string _errorId = Guid.NewGuid().ToString();

            //Create a new log entry
            LogEntry _logEntry = new LogEntry()
            {
                Message = exception.ToString(),
                Priority = priority,
                Severity = TraceEventType.Error,
                EventId = eventId
            };

            _logEntry.ExtendedProperties.Add(new KeyValuePair<string, object>("Message Properties ", logKey));

            //Invoke logger
            Log(_logEntry);
        }

        /// <summary>
        /// Logs message to all configured listeners
        /// </summary>
        /// <param name="severity">Log entry severity</param>
        /// <param name="message">Message to be logged</param>
        /// <param name="eventId">Event number or identifier</param>
        /// <param name="priority">Importance of log message</param>
        public static void LogMessage(TraceEventType severity, string message, int eventId = 0, int priority = 2)
        {
            //Create a new log entry
            LogEntry _logEntry = new LogEntry()
            {
                Message = message,
                Priority = priority,
                Severity = severity,
                EventId = eventId
            };

            //We dont want any extended properties to information log
            _logEntry.ExtendedProperties.Clear();

            //Invoke logger
            Log(_logEntry);
        }

        /// <summary>
        /// Performs logging using Microsoft Enterprise Library Logging Application Block
        /// </summary>
        /// <param name="entry">Log entry to be logged</param>
        private static void Log(LogEntry entry)
        {
            try
            {
                //Initialize MEL logger
                LogWriterFactory _logWriterFactory = new LogWriterFactory();
                Logger.SetLogWriter(_logWriterFactory.Create(), false);

                //Invoke logger to write log entry to configured sources
                Logger.Write(entry);
            }
            catch (Exception ex)
            {
                //Fallback to event log
                try
                {
                    //Get required resource strings
                    string _log = Resource.MessageResource.Resource.LOGGING_FALLBACK_LOG;
                    string _source = Resource.MessageResource.Resource.LOGGING_FALLBACK_SOURCE;

                    //Check if source exists or create source
                    if (!EventLog.SourceExists(_source))
                        EventLog.CreateEventSource(_source, _log);

                    string _message = "Enterprise Library Logging has failed with error: " + ex.ToString() + " Original log entry is:" + entry.Message;

                    //Write entry to event log
                    EventLog.WriteEntry(_source, _message, ConvertSeverityToEntryType(entry.Severity), entry.EventId);
                }
                catch
                {
                    //Logging fallback has been failed too.
                    //Exception supressed
                }
            }
        }

        /// <summary>
        /// Converts TraceEventType to EventLogEntryType
        /// </summary>
        /// <param name="eventType">TraceEventType to Convert</param>
        /// <returns>EventLogEntryType</returns>
        private static EventLogEntryType ConvertSeverityToEntryType(TraceEventType eventType)
        {
            EventLogEntryType _returnValue = EventLogEntryType.Information;

            switch (eventType)
            {
                case TraceEventType.Critical:
                case TraceEventType.Error:
                    _returnValue = EventLogEntryType.Error;
                    break;
                case TraceEventType.Information:
                    _returnValue = EventLogEntryType.Information;
                    break;
                case TraceEventType.Warning:
                    _returnValue = EventLogEntryType.Warning;
                    break;
                default:
                    _returnValue = EventLogEntryType.Information;
                    break;
            }

            return _returnValue;
        }
    }
}

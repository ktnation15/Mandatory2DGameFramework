using System;
using System.Diagnostics;
using System.IO;

namespace Mandatory2DGameFramework.ConfigurationXML
{
    public class MyLogger
    {
        private const string LoggerName = "MyLogger.txt";
        private TraceSource traceSource;

        public MyLogger()
        {
            InitializeLogger();
        }

        private void InitializeLogger()
        {
            traceSource = new TraceSource("MyLogger");
            traceSource.Switch = new SourceSwitch("MyLogger", SourceLevels.All.ToString());

            // Console listener
            traceSource.Listeners.Add(new ConsoleTraceListener());

            // File listener for plain text
            traceSource.Listeners.Add(new TextWriterTraceListener(LoggerName)
            {
                Filter = new EventTypeFilter(SourceLevels.Information)
            });

            // XML file listener
            traceSource.Listeners.Add(new XmlWriterTraceListener($"{LoggerName}.xml"));
        }

        public void LogInformation(string message)
        {
            Log(message, TraceEventType.Information);
        }

        public void LogWarning(string message)
        {
            Log(message, TraceEventType.Warning);
        }

        public void LogError(string message)
        {
            Log(message, TraceEventType.Error);
        }

        public void LogCritical(string message)
        {
            Log(message, TraceEventType.Critical);
        }

        private void Log(string message, TraceEventType eventType)
        {
            traceSource.TraceEvent(eventType, 0, message);
            traceSource.Flush(); // Ensure all messages are written out
        }

        public void Close()
        {
            traceSource.Close(); // Ensure to close the logger when done
        }
    }
}

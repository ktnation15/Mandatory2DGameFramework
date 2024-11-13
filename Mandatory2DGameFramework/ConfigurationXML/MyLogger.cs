using System;
using System.Diagnostics;
using System.IO;

namespace Mandatory2DGameFramework.ConfigurationXML
{
    public class MyLogger
    {
        private const string LoggerName = "MyLogger.txt";
        private TraceSource traceSource;

        // Privat statisk instans, der holder på Singleton-objektet
        private static MyLogger instance;

        // Locking object for tråd-sikkerhed
        private static readonly object lockObj = new object();

        // Privat konstruktør for at forhindre oprettelse af flere instanser
        private MyLogger()
        {
            InitializeLogger();
        }

        // Offentlig statisk metode til at få adgang til den eneste instans
        public static MyLogger Instance
        {
            get
            {
                // Tråd-sikret oprettelse af Singleton instansen
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new MyLogger();
                    }
                    return instance;
                }
            }
        }

        // Initialiser loggeren og dens lyttere
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

        // Metoder til at logge med forskellige eventtyper
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

        // Privat logmetode til at skrive med den angivne eventtype
        private void Log(string message, TraceEventType eventType)
        {
            traceSource.TraceEvent(eventType, 0, message);
            traceSource.Flush(); // Ensure all messages are written out
        }

        // Luk loggeren korrekt
        public void Close()
        {
            traceSource.Close(); // Ensure to close the logger when done
        }
    }
}

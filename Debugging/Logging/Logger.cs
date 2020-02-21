using NgUtil.Chrono;
using NgUtil.Debugging.Contracts;
using NgUtil.Files;
using NgUtil.Files.IO;
using System;
using System.IO;

namespace NgUtil.Debugging.Logging {
    public class Logger {

        public static bool GlobalDebug { get; set; }

        public static string LogFileDir { get; set; } = "./";

        public bool DebugMode { get; set; }

        public string Source { get; }


        public Logger(string source) : this(source, GlobalDebug) { }

        public Logger(string source, bool debug) {
            EmptyParamContract.Validate(source);

            Source = source;
            DebugMode = debug;
        }

        public Logger Info(string message, bool writeLog = false) {
            EmptyParamContract.Validate(message);

            string timestamppedMessage = "[" + DateTimeUtil.GetCurrentDateTimeAsString() + "]: " + message;
            Console.WriteLine("[Info]" + timestamppedMessage);

            if (writeLog) {
                WriteLog("info.txt", timestamppedMessage);
            }
            return this;
        }

        public Logger Warning(string message, bool writeLog = true) {
            EmptyParamContract.Validate(message);

            string timestamppedMessage = "[" + DateTimeUtil.GetCurrentDateTimeAsString() + "]: " + message;
            Console.WriteLine("[Warning]" + timestamppedMessage);

            if (writeLog) {
                WriteLog("warnings.txt", timestamppedMessage);
            }
            return this;
        }

        public Logger Error(string message, bool writeLog = true) {
            EmptyParamContract.Validate(message);

            string timestamppedMessage = "[" + DateTimeUtil.GetCurrentDateTimeAsString() + "]: " + message;
            Console.WriteLine("[Error]" + timestamppedMessage);

            if (writeLog) {
                WriteLog("errors.txt", timestamppedMessage);
            }
            return this;
        }

        public Logger Debug(string message, bool writeLog = false) {
            EmptyParamContract.Validate(message);

            if (DebugMode) {
                return this;
            }
            string timestamppedMessage = "[" + DateTimeUtil.GetCurrentDateTimeAsString() + "]: " + message;
            Console.WriteLine("[Debug]" + timestamppedMessage);

            if (writeLog) {
                WriteLog("debug.txt", timestamppedMessage);
            }
            return this;
        }

        public Logger Exception(Exception ex, bool writeLog = true) {
            EmptyParamContract.Validate(ex);

            if (DebugMode) {
                Console.WriteLine(ex.StackTrace);
            }
            if (writeLog) {
                string safeName = FileHandler.GetSafeFileName(DateTimeUtil.GetCurrentDateTimeAsString());
                WriteLog("/exceptions/" + safeName + ".txt", ex.Message);
            }
            return this;
        }

        public static void WriteLog(string subDir, string message) {
            EmptyParamContract.Validate(message);

            string path = string.IsNullOrEmpty(subDir) ? LogFileDir : Path.Combine(LogFileDir, subDir); 
            
            FileHandler.CreateDirectory(new FileLink(path));

            TextIO.WriteAsync(path, message);
        }

        public static Logger GetLogger(string source) {
            return GetLogger(source, GlobalDebug);
        }

        public static Logger GetLogger(string source, bool debug) {
            return new Logger(source, debug);
        }

    }

}

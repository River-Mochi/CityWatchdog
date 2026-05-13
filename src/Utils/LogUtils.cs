// File: src/Utils/LogUtils.cs
// Purpose: Writes routine City Watchdog log lines directly to the dedicated mod log file.

namespace CityWatchdog
{
    using Colossal.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class LogUtils
    {
        private static readonly object s_WarnOnceLock = new object();
        private static readonly object s_FileWriteLock = new object();

        private static readonly HashSet<string> s_WarnOnceKeys =
            new HashSet<string>(StringComparer.Ordinal);

        private const int MaxWarnOnceKeys = 2048;

        public static bool WarnOnce(string key, Func<string> messageFactory, Exception exception = null)
        {
            return WarnOnce(Mod.s_Log, key, messageFactory, exception);
        }

        public static bool WarnOnce(ILog log, string key, Func<string> messageFactory, Exception exception = null)
        {
            if (log == null || string.IsNullOrEmpty(key) || messageFactory == null)
            {
                return false;
            }

            if (!IsLevelEnabled(log, Level.Warn))
            {
                return false;
            }

            string fullKey = GetLogName(log) + "|" + key;

            lock (s_WarnOnceLock)
            {
                if (s_WarnOnceKeys.Count >= MaxWarnOnceKeys)
                {
                    s_WarnOnceKeys.Clear();
                }

                if (!s_WarnOnceKeys.Add(fullKey))
                {
                    return false;
                }
            }

            TryLog(log, Level.Warn, messageFactory, exception);
            return true;
        }

        public static void Info(Func<string> messageFactory)
        {
            TryLog(Mod.s_Log, Level.Info, messageFactory);
        }

        public static void Info(ILog log, Func<string> messageFactory)
        {
            TryLog(log, Level.Info, messageFactory);
        }

        public static void Warn(Func<string> messageFactory, Exception exception = null)
        {
            TryLog(Mod.s_Log, Level.Warn, messageFactory, exception);
        }

        public static void Warn(ILog log, Func<string> messageFactory, Exception exception = null)
        {
            TryLog(log, Level.Warn, messageFactory, exception);
        }

        public static void Debug(Func<string> messageFactory)
        {
            TryLog(Mod.s_Log, Level.Debug, messageFactory);
        }

        public static void Debug(ILog log, Func<string> messageFactory)
        {
            TryLog(log, Level.Debug, messageFactory);
        }

        public static void Error(Func<string> messageFactory, Exception exception = null)
        {
            TryLog(Mod.s_Log, Level.Error, messageFactory, exception);
        }

        public static void Error(ILog log, Func<string> messageFactory, Exception exception = null)
        {
            TryLog(log, Level.Error, messageFactory, exception);
        }

        public static void TryLog(ILog log, Level level, Func<string> messageFactory, Exception exception = null)
        {
            if (log == null || messageFactory == null)
            {
                return;
            }

            if (!IsLevelEnabled(log, level))
            {
                return;
            }

            string message;
            try
            {
                message = messageFactory() ?? string.Empty;
            }
            catch (Exception ex)
            {
                SafeLogNoException(log, Level.Warn, "Log message factory threw: " + ex.GetType().Name + ": " + ex.Message);
                return;
            }

            try
            {
                AppendDirect(log, level, message, exception);
            }
            catch
            {
            }
        }

        private static void SafeLogNoException(ILog log, Level level, string message)
        {
            try
            {
                if (log != null && IsLevelEnabled(log, level))
                {
                    AppendDirect(log, level, message, null);
                }
            }
            catch
            {
            }
        }

        private static void AppendDirect(ILog log, Level level, string message, Exception exception)
        {
            string logPath = GetLogPath(log);
            if (string.IsNullOrEmpty(logPath))
            {
                return;
            }

            lock (s_FileWriteLock)
            {
                string directory = Path.GetDirectoryName(logPath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (FileStream stream = new FileStream(
                    logPath,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write('[');
                    writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"));
                    writer.Write("] [");
                    writer.Write(GetLevelName(level));
                    writer.Write("]  ");
                    writer.WriteLine(message ?? string.Empty);

                    if (exception != null)
                    {
                        writer.WriteLine(exception);
                    }
                }
            }
        }

        private static string GetLogPath(ILog log)
        {
            try
            {
                if (!string.IsNullOrEmpty(log.logPath))
                {
                    return log.logPath;
                }

                string logName = GetLogName(log);
                if (!string.IsNullOrEmpty(logName))
                {
                    return Path.Combine(LogManager.kDefaultLogPath, logName + ".log");
                }

                return Path.Combine(LogManager.kDefaultLogPath, Mod.ModId + ".log");
            }
            catch
            {
                return Path.Combine(LogManager.kDefaultLogPath, Mod.ModId + ".log");
            }
        }

        private static string GetLogName(ILog log)
        {
            try
            {
                return string.IsNullOrEmpty(log.name) ? Mod.ModId : log.name;
            }
            catch
            {
                return Mod.ModId;
            }
        }

        private static bool IsLevelEnabled(ILog log, Level level)
        {
            try
            {
                return log.isLevelEnabled(level);
            }
            catch
            {
                return true;
            }
        }

        private static string GetLevelName(Level level)
        {
            if (level == Level.Warn)
            {
                return "WARN";
            }

            if (level == Level.Error)
            {
                return "ERROR";
            }

            if (level == Level.Debug)
            {
                return "DEBUG";
            }

            if (level == Level.Trace)
            {
                return "TRACE";
            }

            if (level == Level.Verbose)
            {
                return "VERBOSE";
            }

            return "INFO";
        }
    }
}

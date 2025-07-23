using Logging.View;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Service
{
    public static class LogService
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static void Info(string message)
        {
            logger.Info(message);
            AddToUI("INFO", message);
        }

        public static void Debug(string message)
        {
            logger.Debug(message);
            AddToUI("DEBUG", message);
        }

        public static void Warn(string message)
        {
            logger.Warn(message);
            AddToUI("WARN", message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
            AddToUI("ERROR", message);
        }
        /// <summary>
        /// 拼接格式，与 NLog 文件输出一致
        /// </summary>
        private static void AddToUI(string level, string message)
        {
            string formatted = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.ffff} | {level} | {logger.Name} | {message}";
            // 保证线程安全，放到 UI 线程执行
            LoggingControl.LoggingControlViewModelInstance.LogItems.Add(formatted);
        }
    }
}

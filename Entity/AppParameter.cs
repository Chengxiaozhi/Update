using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MyUpdate.Entity
{
    public class AppParameter
    {
        /// <summary>
        /// 备份路径
        /// </summary>
        public static string BackupPath = ConfigurationManager.AppSettings["backupPath"];

        /// <summary>
        /// 更新的URL
        /// </summary>
        public static string ServerURL = ConfigurationManager.AppSettings["serverURL"];

        /// <summary>
        /// 本地更新文件全名
        /// </summary>
        public static string LocalUPdateConfig = ConfigurationManager.AppSettings["localUPdateConfig"];

        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version = ConfigurationManager.AppSettings["version"];

        /// <summary>
        /// 更新程序路径
        /// </summary>
        public static string LocalPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 主程序路径
        /// </summary>
        public static string MainPath = ConfigurationManager.AppSettings["mainPath"];

        /// <summary>
        /// 有否启动主程序
        /// </summary>
        public static bool IsRunning = false;

        /// <summary>
        /// 主程序名
        /// </summary>
        public static List<string> AppNames = ConfigurationManager.AppSettings["appName"].Split(';').ToList();
    }
}
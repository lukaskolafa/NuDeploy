using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using NuDeploy.Core.Common.FileEncoding;
using NuDeploy.Core.Common.Infrastructure;

namespace NuDeploy.Core.Common.Logging
{
    public class ActionLogger : IActionLogger
    {
        public const string LogFilenamePattern = "NuDeploy.{0}.log";

        public const string ValueSeperator = "\t";

        private readonly ApplicationInformation applicationInformation;

        private readonly Encoding logfileEncoding;

        private readonly Regex tooMuchWhiteSpaceRegex = new Regex("\\s{2,}");

        private readonly string logfilPath;

        private readonly string[] colmns = new[] { "Date", "Time", "UTC-Offset", "User", "Computer", "Message" }; 

        public ActionLogger(ApplicationInformation applicationInformation, IEncodingProvider encodingProvider)
        {
            this.applicationInformation = applicationInformation;
            this.logfileEncoding = encodingProvider.GetEncoding();

            this.logfilPath = this.GetLogfilePath();
            this.InitializeLogFile();
        }

        public void Log(string message, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            string content = this.GetTrimmedMessage(string.Format(message, args));
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            var timestamp = DateTimeOffset.Now;
            string date = timestamp.ToString("yyyy-MM-dd");
            string time = timestamp.ToString("H:mm:ss");
            string utcOffset = string.Concat("UTC", timestamp.ToString("zzz"));
            string user = string.Format("{0}\\{1}", this.applicationInformation.ExecutingUser.Domain, this.applicationInformation.ExecutingUser.Username);
            string computer = this.applicationInformation.MachineName;

            var entry = new[] { date, time, utcOffset, user, computer, content };
            string line = string.Join(ValueSeperator, entry);

            try
            {
                File.AppendAllLines(this.logfilPath, new List<string> {line}, this.logfileEncoding);
            } catch { }
        }

        private void InitializeLogFile()
        {
            try
            {
                if (!File.Exists(this.logfilPath))
                {
                    File.WriteAllText(this.logfilPath, string.Join(ValueSeperator, this.colmns) + Environment.NewLine, this.logfileEncoding);
                }
            } catch { }
        }

        private string GetLogfilePath()
        {
            if (!Directory.Exists(this.applicationInformation.LogFolder))
            {
                Directory.CreateDirectory(this.applicationInformation.LogFolder);
            }

            string logfileName = string.Format(LogFilenamePattern, DateTime.Today.ToString("yyyy-MM-dd"));
            return Path.Combine(this.applicationInformation.LogFolder, logfileName);
        }

        private string GetTrimmedMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }

            var trimmed = message.Trim();
            trimmed = trimmed.Replace("\r\n", string.Empty);
            trimmed = this.tooMuchWhiteSpaceRegex.Replace(trimmed, " ");

            return trimmed;
        }
    }
}
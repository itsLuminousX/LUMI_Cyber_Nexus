using System;
using System.IO;

namespace LUMI_Cyber_Nexus
{
    internal class AsyncLogger
    {
        public static void Log(
            string speaker,
            string message)
        {
            string line =
                $"{DateTime.Now} [{speaker}] {message}";

            File.AppendAllText(
                "chatlog.txt",
                line + Environment.NewLine);
        }
    }
}
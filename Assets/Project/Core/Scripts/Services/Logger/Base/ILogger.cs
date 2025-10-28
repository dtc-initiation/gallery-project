using System;

namespace Project.Core.Scripts.Services.Logger.Base {
    public interface ILogger {
        void Log(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogException(Exception exception);
        void LogTopic(string message, LogTopic topic = Base.LogTopic.Temp, string callerFilePath = "", string callerMemberName = "");
    }
}
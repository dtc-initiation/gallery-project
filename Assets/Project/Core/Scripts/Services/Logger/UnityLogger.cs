using System;
using System.Collections.Generic;
using System.IO;
using Project.Core.Scripts.Services.Logger.Base;
using UnityEngine;

namespace Project.Core.Scripts.Services.Logger {
    public class UnityLogger : LoggerBase {
        private const string DebugTopicSuffix = ":: ";
        private const string Dot = ".";
        private const string StampFormat = "[{0}]";
        private const string TimeStampFormat = "HH:mm:ss:ff";
        
        private readonly Dictionary<LogLevel, Color> LogColors = new() {
            { LogLevel.Info , Color.floralWhite},
            { LogLevel.Error , Color.crimson},
            { LogLevel.Warning , Color.yellowGreen},
            { LogLevel.Topic , Color.darkCyan }
        };

        public override void Log(string message) {
            var coloredMessage = ColorLogLevel(message, LogLevel.Info);
            Debug.Log(GetTimeStamp() + message);
        }

        public override void LogError(string message) {
            var coloredMessage = ColorLogLevel(message, LogLevel.Error);
            Debug.LogError(GetTimeStamp() + message);
        }

        public override void LogWarning(string message) {
            var coloredMessage = ColorLogLevel(message, LogLevel.Warning);
            Debug.LogWarning(GetTimeStamp() + message);
        }

        public override void LogException(Exception exception) {
            Debug.LogException(exception);
        }

        public override void LogTopic(string message, LogTopic topic = Base.LogTopic.Temp, string callerFilePath = "", string callerMemberName = "") {
            var coloredMessage = ColorLogLevel(message, topic);
            Debug.Log(GetTimeStamp() + coloredMessage + string.Format(StampFormat, GetCallerName(callerFilePath) + Dot + callerMemberName));
        }

        private string ColorLogLevel(string message, LogLevel level) {
            var levelColorHex = ColorUtility.ToHtmlStringRGBA(LogColors[level]);
            var coloredMessage = $"<color=#{levelColorHex}>[{level}]</color> {message}";
            return coloredMessage;
        }

        private string ColorLogLevel(string message, LogTopic topic) {
            var levelColorHex = ColorUtility.ToHtmlStringRGBA(LogColors[LogLevel.Topic]);
            var coloredMessage = $"<color=#{levelColorHex}>[{topic}]</color> {DebugTopicSuffix} {message}";
            return coloredMessage;
        }
        
        
        private string GetTimeStamp() {
            var timestamp = DateTime.Now.ToString(TimeStampFormat);
            // return $"[{timestamp}]";
            return string.Format(StampFormat, timestamp);
        }

        private string GetCallerName(string callerFilePath) {
            return Path.GetFileNameWithoutExtension(callerFilePath);
        }

    }
}
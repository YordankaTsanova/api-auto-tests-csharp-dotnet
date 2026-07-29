using System;
using System.IO;

namespace ApiTestDemo.Utils
{
    public static class TestLogger
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

        static TestLogger()
        {
            Directory.CreateDirectory(LogDirectory);
        }

        public static void LogFailure(string scenario, string message)
        {
            var filePath = Path.Combine(LogDirectory, $"{DateTime.UtcNow:yyyyMMdd_HHmmss}_{Guid.NewGuid():N}.log");
            File.WriteAllText(filePath, $"[{DateTime.UtcNow:O}] {scenario}\n{message}\n");
        }
    }
}

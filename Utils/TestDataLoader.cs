using System;
using System.IO;
using System.Text.Json;

namespace ApiTestDemo.Utils
{
    public static class TestDataLoader
    {
        public static T LoadJson<T>(string fileName)
        {
            // Build the full path to TestData/fileName
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Test data file not found at: {filePath}");
            }

            string jsonContent = File.ReadAllText(filePath);

            // JsonNamingPolicy.CamelCase allows C# PascalCase properties to automatically match camelCase JSON keys
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Deserialize<T>(jsonContent, options) 
                   ?? throw new InvalidOperationException($"Failed to deserialize {fileName} to type {typeof(T).Name}");
        }
    }
}
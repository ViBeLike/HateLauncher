using System;
using System.IO;

namespace HyTaLauncher
{
    public static class Config
    {
        // API key - loaded from .env file or environment variable
        private static string? _curseForgeApiKey;
        
        public static string CurseForgeApiKey
        {
            get
            {
                if (_curseForgeApiKey == null)
                {
                    _curseForgeApiKey = LoadApiKey();
                }
                return _curseForgeApiKey;
            }
        }
        
        private static string LoadApiKey()
        {
            // 1. Try environment variable first
            var envKey = Environment.GetEnvironmentVariable("CURSEFORGE_API_KEY");
            if (!string.IsNullOrEmpty(envKey))
                return envKey;
            
            // 2. Try .env file in app directory
            var envPaths = new[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".env"), // Debug from VS
                ".env"
            };
            
            foreach (var envPath in envPaths)
            {
                if (File.Exists(envPath))
                {
                    foreach (var line in File.ReadAllLines(envPath))
                    {
                        var trimmed = line.Trim();
                        if (trimmed.StartsWith("CURSEFORGE_API_KEY="))
                        {
                            return trimmed.Substring("CURSEFORGE_API_KEY=".Length).Trim();
                        }
                    }
                }
            }
            
            // 3. Fallback - placeholder (will be replaced at build time for releases)
            var placeholder = "#{CURSEFORGE_API_KEY}#";
            if (!placeholder.StartsWith("#"))
                return placeholder;
            
            return "";
        }
    }
}

















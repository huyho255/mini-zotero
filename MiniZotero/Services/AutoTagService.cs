using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniZotero.Services
{
    public sealed class AutoTagService
    {
        private static readonly Dictionary<string, string[]> Rules = new(StringComparer.OrdinalIgnoreCase)
        {
            ["C#"] = ["csharp", "c#", ".net", "dotnet", "avalonia", "wpf", "oop", "class", "inheritance"],
            ["CMOS"] = ["cmos", "mosfet", "inverter", "spice", "cadence", "opamp"],
            ["Embedded"] = ["stm32", "esp32", "arduino", "uart", "adc", "pwm", "freertos"],
            ["Datasheet"] = ["datasheet", "specification", "max30102", "mpu6050"],
            ["Paper"] = ["abstract", "ieee", "references", "journal", "conference"],
            ["Circuit"] = ["schematic", "pcb", "altium", "ltspice", "simulation"]
        };

        public IReadOnlyList<string> GenerateTags(string filePath, string title)
        {
            var folderName = Path.GetDirectoryName(filePath) is { } folderPath
                ? Path.GetFileName(folderPath)
                : string.Empty;

            var source = $"{filePath} {folderName} {title}".ToLowerInvariant();
            var tags = new List<string>();

            foreach (var rule in Rules)
            {
                if (rule.Value.Any(keyword => source.Contains(keyword.ToLowerInvariant())))
                {
                    tags.Add(rule.Key);
                }
            }

            return tags
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
    }
}

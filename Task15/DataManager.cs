using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class DataManager
{
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public void Save(List<Vehicle> vehicles, string filePath)
    {
        string json = JsonSerializer.Serialize(vehicles, options);
        File.WriteAllText(filePath, json);
    }

    public List<Vehicle> Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Vehicle>();
        }

        string json = File.ReadAllText(filePath);
        List<Vehicle>? loaded = JsonSerializer.Deserialize<List<Vehicle>>(json, options);
        return loaded ?? new List<Vehicle>();
    }
}
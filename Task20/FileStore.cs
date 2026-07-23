using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class FileStore<T> : IStore<T> where T : IIdentifiable
{
    private string filePath;
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public FileStore(string filePath)
    {
        this.filePath = filePath;
    }

    private List<T> LoadAll()
    {
        if (!File.Exists(filePath)) return new List<T>();
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
    }

    private void SaveAll(List<T> items)
    {
        string json = JsonSerializer.Serialize(items, options);
        File.WriteAllText(filePath, json);
    }

    public void Add(T item)
    {
        List<T> items = LoadAll();
        items.Add(item);
        SaveAll(items);
    }

    public void Remove(string id)
    {
        List<T> items = LoadAll();
        items.RemoveAll(i => i.Id == id);
        SaveAll(items);
    }

    public T? Find(string id)
    {
        return LoadAll().FirstOrDefault(i => i.Id == id);
    }

    public List<T> GetAll()
    {
        return LoadAll();
    }

    public List<T> Filter(Func<T, bool> condition)
    {
        return LoadAll().Where(condition).ToList();
    }

    public int Count => LoadAll().Count;
}
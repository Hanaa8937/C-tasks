using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

public class JsonRepository<T> : IRepository<T> where T : IIdentifiable
{
    private string filePath;
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };

    public JsonRepository(string filePath)
    {
        this.filePath = filePath;
    }

    private async Task<List<T>> LoadAllAsync()
    {
        if (!File.Exists(filePath)) return new List<T>();
        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
    }

    private async Task SaveAllAsync(List<T> items)
    {
        string json = JsonSerializer.Serialize(items, options);
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task<T?> GetAsync(string id)
    {
        List<T> items = await LoadAllAsync();
        return items.FirstOrDefault(i => i.Id == id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await LoadAllAsync();
    }

    public async Task AddAsync(T item)
    {
        List<T> items = await LoadAllAsync();
        items.Add(item);
        await SaveAllAsync(items);
    }

    public async Task UpdateAsync(T item)
    {
        List<T> items = await LoadAllAsync();
        int index = items.FindIndex(i => i.Id == item.Id);
        if (index >= 0)
        {
            items[index] = item;
            await SaveAllAsync(items);
        }
    }

    public async Task DeleteAsync(string id)
    {
        List<T> items = await LoadAllAsync();
        items.RemoveAll(i => i.Id == id);
        await SaveAllAsync(items);
    }

    public async Task<List<T>> FilterAsync(Func<T, bool> condition)
    {
        List<T> items = await LoadAllAsync();
        return items.Where(condition).ToList();
    }
}
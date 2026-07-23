using System;
using System.Collections.Generic;
using System.Linq;

public class MemoryStore<T> : IStore<T> where T : IIdentifiable
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(string id)
    {
        T? toRemove = items.FirstOrDefault(i => i.Id == id);
        if (toRemove != null)
        {
            items.Remove(toRemove);
        }
    }

    public T? Find(string id)
    {
        return items.FirstOrDefault(i => i.Id == id);
    }

    public List<T> GetAll()
    {
        return items;
    }

    public List<T> Filter(Func<T, bool> condition)
    {
        return items.Where(condition).ToList();
    }

    public int Count => items.Count;
}
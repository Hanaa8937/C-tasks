using System;
using System.Collections.Generic;

public interface IStore<T> where T : IIdentifiable
{
    void Add(T item);
    void Remove(string id);
    T? Find(string id);
    List<T> GetAll();
    List<T> Filter(Func<T, bool> condition);
    int Count { get; }
}
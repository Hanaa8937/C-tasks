using System;

public class VehicleService
{
    private IStore<Vehicle> store;

    // This is "constructor injection" — the service receives
    // whatever IStore<Vehicle> it's handed. It has no idea (and
    // doesn't need to know) if that's a MemoryStore, a FileStore,
    // or something else entirely.
    public VehicleService(IStore<Vehicle> store)
    {
        this.store = store;
    }

    public void AddVehicle(Vehicle v)
    {
        store.Add(v);
    }

    public int Count => store.Count;

    public void ListAll()
    {
        foreach (Vehicle v in store.GetAll())
        {
            Console.WriteLine(v.Summary());
        }
    }
}
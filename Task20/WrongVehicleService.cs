using System;

// WRONG WAY: this class creates its own Store internally
public class WrongVehicleService
{
    private MemoryStore<Vehicle> store = new MemoryStore<Vehicle>();

    public WrongVehicleService()
    {
        // The problem: this service is now permanently stuck using
        // exactly this one Store. You can't swap it for a file-based
        // store or a test version without editing this class's code.
    }

    public void Add(Vehicle v)
    {
        store.Add(v);
    }

    public int Count => store.Count;
}
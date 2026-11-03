Console.WriteLine("\n--- Validation tests ---");

TryCreate(() => new Refrigerator("fridge1", "Ahmad", due, 300));                         // bad serial
TryCreate(() => new WashingMachine("WM-2002", "", due, 8, true));                        // empty owner
TryCreate(() => new AirConditioner("AC-3002", "Omar", DateTime.Now.AddDays(-1), 18000, false)); // past date
TryCreate(() => new Refrigerator("FR-1002", "Lina", due, 0));                            // capacity 0

static void TryCreate(Func<Appliance> create)
{
    try
    {
        create();
        Console.WriteLine("Accepted (unexpected!)");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"Rejected: {e.Message}");
    }
}

using RepairCenter.Models;
using RepairCenter.Services;

var manager = new RepairCenterManager();
manager.DeviceOverdue += d => Console.WriteLine($"[Overdue] {d.SerialNumber} ({d.OwnerName}) is late!");

var due = DateTime.Now.AddDays(5);

var fridge = new Refrigerator("FR-1001", "Ahmad", due, capacityLiters: 550, requiresGasRefill: true);
var washer = new WashingMachine("WM-2001", "Lina", due, maxLoadKg: 8, isFrontLoad: true, hasWaterLeak: true);
var ac = new AirConditioner("AC-3001", "Omar", due, coolingCapacityBtu: 24000, isInverter: true);

foreach (Appliance d in new Appliance[] { fridge, washer, ac })
{
    d.LaborHours = 2;
    d.PartsCost = 50;
    manager.AddDevice(d);
}

Console.WriteLine("--- All devices ---");
manager.PrintAllSummaries();
Console.WriteLine($"Total cost: {manager.GetTotalCost():C}");

Console.WriteLine("\n--- Repair workflow ---");
fridge.StartRepair();
fridge.CompleteRepair();
ac.StartRepair();
ac.CompleteRepair();

Console.WriteLine($"\nRepaired devices: {RepairCenterManager.RepairedDevicesCount}");
Console.WriteLine($"Repaired revenue: {RepairCenterManager.TotalRepairedRevenue:C}");
Console.WriteLine($"Still received: {manager.GetDevicesByStatus(RepairCenter.Enums.DeviceStatus.Received).Count()}");

Console.WriteLine("\n--- Overdue check ---");
// A delivery date of today is valid, but midnight has already passed, so it counts as late.
manager.AddDevice(new WashingMachine("WM-2002", "Sara", DateTime.Today, 7, false));
manager.CheckOverdueDevices();

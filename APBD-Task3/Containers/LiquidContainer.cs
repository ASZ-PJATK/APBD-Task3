// Liquid Container, derived from standard container.

namespace APBD_Task3.Containers;

public class LiquidContainer(double maxPayload, double tareWeight, bool isHazardous)
    : Container(maxPayload, tareWeight, "L"), IHazardNotifier
{
    private bool IsHazardous { get; } = isHazardous;

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazard Alert! Overloading risk for container {containerNumber}.");
    }

    public override void LoadCargo(double weight)
    {
        var limit = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (weight > limit)
            NotifyHazard(SerialNumber);
        base.LoadCargo(weight);
    }
}
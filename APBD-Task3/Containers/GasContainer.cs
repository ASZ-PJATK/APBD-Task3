// Gas container, derived from standard container.

namespace APBD_Task3.Containers;

public class GasContainer(double maxPayload, double tareWeight, double pressure)
    : Container(maxPayload, tareWeight, "G"), IHazardNotifier
{
    public double Pressure { get; } = pressure;

    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazard Alert! Gas container {containerNumber} may be dangerous.");
    }

    public override void UnloadCargo()
    {
        Mass *= 0.05; // Leaves 5% of cargo
    }
}
// Base container class

namespace APBD_Task3.Containers;

public abstract class Container
{
    private static int _counter = 1;

    protected Container(double maxPayload, double tareWeight, string type)
    {
        MaxPayload = maxPayload;
        TareWeight = tareWeight;
        SerialNumber = $"KON-{type}-{_counter++}";
    }

    public string SerialNumber { get; }
    public double Mass { get; protected set; }
    public double MaxPayload { get; }
    public double TareWeight { get; }

    public virtual void LoadCargo(double weight)
    {
        if (weight > MaxPayload)
            throw new OverfillException("Exceeded maximum payload.");
        Mass = weight;
    }

    public virtual void UnloadCargo()
    {
        Mass = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber} - {Mass}/{MaxPayload}kg";
    }
}
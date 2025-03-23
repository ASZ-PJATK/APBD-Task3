// The container ships in question:

using APBD_Task3.Containers;

namespace APBD_Task3;

public class Ship(int maxContainers, double maxWeight, double speed)
{
    private List<Container> Containers { get; } = new();
    private int MaxContainers { get; } = maxContainers;
    private double MaxWeight { get; } = maxWeight;
    private double Speed { get; } = speed;

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers || GetTotalWeight() + container.Mass > MaxWeight)
            throw new OverfillException("Ship Overloaded!");
        Containers.Add(container);
    }

    public void LoadContainerList(List<Container> containers)
    {
        foreach (var container in containers)
            try
            {
                LoadContainer(container);
            }
            catch (OverfillException)
            {
                Console.WriteLine($"Cannot load container {container.SerialNumber}: Ship Overloaded!");
            }
    }


    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void ReplaceContainer(Container targetContainer, Container replacementContainer)
    {
        for (var i = 0; i < Containers.Count; i++)
            if (Containers[i] == targetContainer)
            {
                Containers[i] = replacementContainer;
                return;
            }

        throw new ArgumentException("Container not found.");
    }

    public void TransferContainer(Container targetContainer, Ship targetShip)
    {
        targetShip.LoadContainer(targetContainer);
        UnloadContainer(targetContainer);
    }

    private double GetTotalWeight()
    {
        double total = 0;
        foreach (var container in Containers)
            total += container.Mass + container.TareWeight;
        return total;
    }

    public override string ToString()
    {
        var containerDetails = string.Join("\n  ", Containers.Select(c => c.ToString()));
        return
            $"===Ship Info===\nSpeed: {Speed} knots\nLoaded containers: {Containers.Count}/{MaxContainers}\nWeight: {GetTotalWeight()}/{MaxWeight}kg\nContainers:\n  {containerDetails}\n===============";
    }
}
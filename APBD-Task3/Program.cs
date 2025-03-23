// Container ship management app main class

using APBD_Task3.Containers;

namespace APBD_Task3;

internal static class Program
{
    private static void Main()
    {
        // 1. Create containers of given type
        var liquidContainer = new LiquidContainer(100, 20, false);
        var liquidContainerHazard = new LiquidContainer(200, 45, true);
        var gasContainer = new GasContainer(250, 20, 5);
        var refrigeratedContainer = new RefrigeratedContainer(500, 80, "Bananas", 15);

        // 2. Loading cargo
        liquidContainer.LoadCargo(60);
        liquidContainerHazard.LoadCargo(100);
        gasContainer.LoadCargo(200);
        refrigeratedContainer.LoadCargo(480);

        // 3. Creating ships
        var borealis = new Ship(4, 350, 30);
        var evergreen = new Ship(8, 800, 12);

        // 4. Loading a single container onto a ship
        borealis.LoadContainer(liquidContainerHazard);

        // 5. Loading a list of containers onto a ship
        List<Container> shipment = [liquidContainer, gasContainer, refrigeratedContainer];
        evergreen.LoadContainerList(shipment);

        // 6. Removing a container from the ship
        evergreen.UnloadContainer(gasContainer);

        // 7. Unloading a container
        liquidContainerHazard.UnloadCargo();

        // 8. Replacing a container
        var replacementLiquidContainer = new LiquidContainer(80, 10, false);
        borealis.ReplaceContainer(liquidContainerHazard, replacementLiquidContainer);

        // 9. Transfer a container from one ship to another
        evergreen.TransferContainer(liquidContainer, borealis);

        // 10. Print container information
        Console.WriteLine("Refrigerated container information:\n" + refrigeratedContainer);

        // 11. Print ship information
        Console.WriteLine("Evergreen container information:\n" + evergreen);
    }
}
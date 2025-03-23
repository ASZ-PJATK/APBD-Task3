// Refrigerated Container, derived from standard container.

namespace APBD_Task3.Containers;

public class RefrigeratedContainer : Container
{
    private static readonly Dictionary<string, double> ProductMinTemp = new()
    {
        { "Bananas", 13.3 },
        { "Fish", -2.0 },
        { "Meat", -18.0 },
        { "Apples", 4.0 }
    };

    public RefrigeratedContainer(double maxPayload, double tareWeight, string productType, double temperature)
        : base(maxPayload, tareWeight, "C")
    {
        if (!ProductMinTemp.ContainsKey(productType))
            throw new ArgumentException($"Invalid product type: {productType}");

        if (temperature < ProductMinTemp[productType])
            throw new ArgumentException(
                $"Temperature too low for {productType}. Must be at least {ProductMinTemp[productType]}°C");

        ProductType = productType;
        Temperature = temperature;
    }

    public string ProductType { get; }
    public double Temperature { get; }
}
namespace Lab02_Pipelines;

public static class OrderFunctions
{
    public static void ApplyDiscountStep(OrderContext context, int discountPercentage)
    {
        ApplyDiscount_Adapter(context.Order, discountPercentage);
    }
    
    public static void AddShippingStep(OrderContext context, double shippingCost)
    {
        AddShipping_Adapter(context.Order, shippingCost);
    }

    public static void PrintOrder(OrderContext context)
    {
        PrintOrder_Adapter(context.Order);
    }

    private static void ApplyDiscount_Adapter(Order order, int discountPercentage)
    {
        Console.WriteLine($"Applying discount to {order.Price} with {discountPercentage}% price");
        order.Price -= discountPercentage;
    }
    private static void AddShipping_Adapter(Order order, double shippingCost)
    {
        Console.WriteLine($"Adding shipping cost to {order.Price} with ${shippingCost} cost");
        order.Price += shippingCost;
    }

    private static void PrintOrder_Adapter(Order order)
    {
        Console.WriteLine($"Order number : {order.OrderNumber}");
        Console.WriteLine($"Order status : {order.Status}");
        Console.WriteLine($"Customer name : {order.CustomerName}");
        Console.WriteLine($"Total Order Price : {order.Price}");
    }
}
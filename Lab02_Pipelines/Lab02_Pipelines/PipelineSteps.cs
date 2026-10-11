namespace Lab02_Pipelines;

sealed class ApplyDiscountPipelineStep : IPipelineStep
{
    public required int _discountPercentage;
    
    public void Execute(OrderContext context)
    {
        OrderFunctions.ApplyDiscountStep(context, _discountPercentage);
    }

    public void Introspect()
    {
        Console.WriteLine("ApplyDiscountPipelineStep");
    }
}

sealed class AddShippingPipelineStep : IPipelineStep
{
    public required double _shippingCost;

    public void Execute(OrderContext context)
    {
        OrderFunctions.AddShippingStep(context, _shippingCost);
    }

    public void Introspect()
    {
        Console.WriteLine("AddShippingPipelineStep");
    }
}

sealed class PrintOrderPipelineStep : IPipelineStep
{
    public void Execute(OrderContext context)
    {
        OrderFunctions.PrintOrder(context);
    }

    public void Introspect()
    {
        Console.WriteLine("PrintOrderPipelineStep");
    }
}
using System.Text;

namespace Lab02_Pipelines;

sealed class ApplyDiscountPipelineStep : IPipelineStep
{
    public required int _discountPercentage;
    
    public void Execute(OrderContext context)
    {
        OrderFunctions.ApplyDiscountStep(context, _discountPercentage);
    }

    public void Introspect(StringBuilder sb)
    {
        sb.AppendLine($"ApplyDiscount({_discountPercentage}%)");
    }
}

sealed class AddShippingPipelineStep : IPipelineStep
{
    public required double _shippingCost;

    public void Execute(OrderContext context)
    {
        OrderFunctions.AddShippingStep(context, _shippingCost);
    }

    public void Introspect(StringBuilder sb)
    {
        sb.AppendLine($"AddShipping(${_shippingCost:F2})");
    }
}

sealed class PrintOrderPipelineStep : IPipelineStep
{
    public static readonly PrintOrderPipelineStep Instance = new PrintOrderPipelineStep();

    private PrintOrderPipelineStep()
    {
        
    }
    public void Execute(OrderContext context)
    {
        OrderFunctions.PrintOrder(context);
    }

    public void Introspect(StringBuilder sb)
    {
        sb.AppendLine("PrintOrderPipelineStep");
    }
}

sealed class OrderValidationDecorator(IPipelineStep step) : IPipelineStep
{
    public void Execute(OrderContext context)
    {
        if (context.Order.Price <= 0)
        {
            Console.WriteLine("Invalid order price");
            context.IsDone = true;
            return;
        }

        step.Execute(context);
    }

    public void Introspect(StringBuilder sb)
    {
        sb.AppendLine("OrderValidationDecorator");
        step.Introspect(sb);
    }
}

sealed class PriceChangeDecorator : IPipelineStep
{
    private readonly IPipelineStep _step;

    public PriceChangeDecorator(IPipelineStep step)
    {
        _step = step;
    }

    public void Execute(OrderContext context)
    {
        double priceBefore = context.Order.Price;

        _step.Execute(context);

        double priceAfter = context.Order.Price;

        Console.WriteLine($"Price before: {priceBefore}");
        Console.WriteLine($"Price after: {priceAfter}");
        Console.WriteLine($"Difference: {priceAfter - priceBefore}");
    }

    public void Introspect(StringBuilder sb)
    {
        sb.AppendLine("PriceChangeDecorator");
        _step.Introspect(sb);
    }
}
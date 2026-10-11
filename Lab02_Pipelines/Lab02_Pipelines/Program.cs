using Lab02_Pipelines;

var order1 = new Order()
{
    OrderNumber = 1,
    CustomerName = "John Doe",
    Price = 1000.00,
    Status = OrderStatus.Pending,
    CustomerType = CustomerType.Regular
};
var orderContext = new OrderContext()
{
    Order = order1,
    Messages = []
};

var examplePipeline = new Pipeline(
[
    new ApplyDiscountPipelineStep()
    {
        _discountPercentage = 10
    },
    new AddShippingPipelineStep()
    {
        _shippingCost = 50.00
    },
    new PrintOrderPipelineStep()
]);

while (true)
{
    Console.Write("Enter new step: ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "AddDiscount":
        {
            int discount = int.Parse(Console.ReadLine());
            examplePipeline.AddStep(new ApplyDiscountPipelineStep()
            {
                _discountPercentage = discount
            });
            break;
        }
        case "AddShipping":
        {
            var shippingCost = int.Parse(Console.ReadLine());
            examplePipeline.AddStep(new AddShippingPipelineStep()
            {
                _shippingCost = shippingCost
            });
            break;
        }
        case "PrintOrder":
        {
            examplePipeline.AddStep(new PrintOrderPipelineStep());
            break;
        }
        case "Introspect":
        {
            examplePipeline.Introspect(orderContext);
            break;
        }
        case "Execute":
        {
            examplePipeline.Execute(orderContext);
            break;
        }
    }
}


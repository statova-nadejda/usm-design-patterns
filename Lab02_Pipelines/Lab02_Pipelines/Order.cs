namespace Lab02_Pipelines;

public class Order
{
    public int OrderNumber { get; set; }
    public required string CustomerName { get; set; }
    public double Price { get; set; }
    public OrderStatus Status { get; set; }
    public CustomerType CustomerType { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Completed,
}
public enum CustomerType
{
    Regular,
    Premium,
}
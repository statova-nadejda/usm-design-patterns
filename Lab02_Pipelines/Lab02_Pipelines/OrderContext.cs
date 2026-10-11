namespace Lab02_Pipelines;

public class OrderContext
{
    public required Order Order { get; set; }
    public List<string> Messages { get; set; } = [];
}
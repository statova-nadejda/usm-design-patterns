using System.Text;
using Lab02_Pipelines;

sealed class Pipeline
{
    private readonly List<IPipelineStep> _steps;

    public Pipeline()
    {
        _steps = [];
    }

    public Pipeline(IEnumerable<IPipelineStep> steps)
    {
        _steps = steps.ToList();
    }

    public void AddStep(IPipelineStep step)
    {
        _steps.Add(step);
    }

    public void Execute(OrderContext context)
    {
        foreach (var step in _steps)
        {
            if (context.IsDone)
            {
                break;
            }
            step.Execute(context);
        }
    }

    public string Introspect(OrderContext context)
    {
        var sb = new StringBuilder();
        foreach (var step in _steps)
        {
            step.Introspect(sb);
        }
        return sb.ToString();
    }

    public void PrintSteps(OrderContext context)
    {
        Console.WriteLine(Introspect(context));
    }
}
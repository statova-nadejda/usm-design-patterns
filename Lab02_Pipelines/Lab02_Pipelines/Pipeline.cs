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
            step.Execute(context);
        }
    }

    public void Introspect(OrderContext context)
    {
        foreach (var step in _steps)
        {
            step.Introspect();
        }
    }
}
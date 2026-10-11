using System.Text;

namespace Lab02_Pipelines;

public interface IPipelineStep
{
    void Execute(OrderContext context);
    void Introspect(StringBuilder sb);
}
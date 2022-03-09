using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator
{
    public interface IFirstCalculator
    {
        FirstCalculatorResult[] Calculate(FirstAnalyzeResult[] p_firstAnalyzeResults);
    }
}
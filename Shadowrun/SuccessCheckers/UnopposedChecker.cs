namespace Shadowrun.SuccessCheckers;

using Results;

public abstract class UnopposedChecker : ISuccessChecker
{
    protected UnopposedChecker(Threshold threshold)
    {
        this.Threshold = threshold;
    }

    protected Threshold Threshold { get; }

    public abstract RollResult CheckSuccess(int dieCount, bool usingEdge);
}
namespace Shadowrun.SuccessCheckers;

using Results;

public class BuyHitsChecker : UnopposedChecker
{
    public BuyHitsChecker(Threshold threshold)
        : base(threshold)
    {
    }

    public override RollResult CheckSuccess(int dieCount, bool usingEdge)
    {
        var boughtDice = dieCount / 4;
        var netHits = boughtDice - (int)this.Threshold;
        var result = netHits > 0 ? ResultType.Success : ResultType.Failure;
        return new RollResult(netHits, result);
    }
}
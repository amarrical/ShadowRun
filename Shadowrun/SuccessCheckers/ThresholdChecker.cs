using Shadowrun.Dice;
using Shadowrun.Dice.Factories;
using Shadowrun.Results;

namespace Shadowrun.SuccessCheckers;

public class ThresholdChecker : UnopposedChecker
{
    private readonly IDieFactory dieFactory;

    public ThresholdChecker(Threshold threshold, IDieFactory? factory = null)
        : base(threshold)
    {
        this.dieFactory = factory ?? new DieFactory();
    }

    public override RollResult CheckSuccess(int dieCount, bool usingEdge)
    {
        var dice = this.dieFactory.GenerateDice(dieCount, usingEdge);
        var roll = dice.Roll();
        return roll.Result(this.Threshold);
    }
}
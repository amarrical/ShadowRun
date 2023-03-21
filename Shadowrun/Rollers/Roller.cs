using Shadowrun.Dice;

namespace Shadowrun.Rollers;

public class Roller : IRoller
{
    private IDieFactory dieFactory;

    public Roller(IDieFactory? factory = null)
    {
        this.dieFactory = factory ?? new DieFactory();
    }

    public RollResult CheckSuccess(int dieCount, int threshold, bool usingEdge)
    {
        var dice = this.dieFactory.GenerateDice(dieCount, usingEdge);
        var result =  dice.Sum();
        var success = result.Hits >= threshold;
        var glitch = result.Ones >= (dieCount + 1) / 2; // Adding 1 so odd die counts calculate correctly
        var netHits = success ? result.Hits - threshold : 0;
        var overallResult = glitch switch
        {
            true => success switch
            {
                true => RollResult.Result.Glitch,
                false => RollResult.Result.CriticalGlitch
            },
            false => success switch
            {
                true => RollResult.Result.Success,
                false => RollResult.Result.Failure
            }
        };

        return new RollResult(netHits, overallResult);
    }
}
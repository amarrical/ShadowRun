using Shadowrun.Dice;

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
        return glitch switch
        {
            true => success switch
            {
                true => RollResult.Glitch,
                false => RollResult.CriticalGlitch
            },
            false => success switch
            {
                true => RollResult.Success,
                false => RollResult.Failure
            }
        };
    }
}
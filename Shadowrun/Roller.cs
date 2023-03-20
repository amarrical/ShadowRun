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
        return dice.Sum(d => d.RollHits()) >= threshold ? RollResult.Success : RollResult.Failure;
    }
}

public enum RollResult
{
    Success,
    Failure,
    Glitch,
    CriticalGlitch
}
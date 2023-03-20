namespace Shadowrun;

public class Die : IDie
{
    private IRng rng;

    public Die(IRng? rng = null)
    {
        this.rng = rng ?? new Rng();
    }

    public int RollHits()
    {
        return rng.Next(1, 6) switch
        {
            < 5 => 0,
            5 => 1,
            6 => 1,
            _ => throw new Exception("Roll not between 1 and 6")
        };
    }

}
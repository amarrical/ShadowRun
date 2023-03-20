using System.ComponentModel.DataAnnotations;

namespace Shadowrun;

public class EdgeDie : IDie
{
    private IRng rng;

    public EdgeDie(IRng? rng = null)
    {
        this.rng = rng ?? new Rng();
    }

    public int RollHits()
    {
        return rng.Next(1, 6) switch
        {
            < 5 => 0,
            5 => 1,
            6 => 1 + this.RollHits(),
            _ => throw new Exception("Roll not between 1 and 6")
        };
    }
}
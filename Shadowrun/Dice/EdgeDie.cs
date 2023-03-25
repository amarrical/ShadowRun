using Shadowrun.Results;

namespace Shadowrun.Dice;

public class EdgeDie : IDie
{
    private readonly IRng rng;

    public EdgeDie(IRng? rng = null)
    {
        this.rng = rng ?? new Rng();
    }

    public DieResult Roll()
    {
        return this.rng.Next(1, 6) switch
        {
            1 => new DieResult(0, 1),
            < 5 => new DieResult(0, 0),
            5 => new DieResult(1, 0),
            6 => new DieResult(1, 0) + this.Roll(),
            _ => throw new Exception("Roll not between 1 and 6")
        };
    }
}
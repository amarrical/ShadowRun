using Shadowrun.Results;

namespace Shadowrun.Dice;

public class Die : IDie
{
    private readonly IRng rng;

    public Die(IRng? rng = null)
    {
        this.rng = rng ?? new Rng();
    }

    public DieResult RollHits()
    {
        return this.rng.Next(1, 6) switch
        {
            1 => new DieResult(0, 1, 1),
            < 5 => new DieResult(0, 0, 1),
            >=5 => new DieResult(1, 0, 1),
        };
    }
}
using System.Runtime.CompilerServices;
using Shadowrun.Results;

namespace Shadowrun.Dice;

public static class IDieExtensions
{
    public static DieResult Roll(this ICollection<IDie> dice)
    {
        return dice.Select(d => d.RollHits()).Roll();
    }

    public static DieResult Roll(this IEnumerable<DieResult> results)
    {
        return results.Aggregate((x, y) => x + y);
    }
}
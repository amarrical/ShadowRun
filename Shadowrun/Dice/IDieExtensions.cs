using System.Runtime.CompilerServices;

namespace Shadowrun.Dice;

public static class IDieExtensions
{
    public static DieResult Sum(this ICollection<IDie> dice)
    {
        return dice.Select(d => d.RollHits()).Sum();
    }

    public static DieResult Sum(this IEnumerable<DieResult> results)
    {
        return results.Aggregate((x, y) => x + y);
    }
}
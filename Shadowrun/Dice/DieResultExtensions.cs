using Shadowrun.Results;

namespace Shadowrun.Dice;

public static class DieResultExtensions
{
    public static DieResult Tally(this IEnumerable<DieResult> results)
    {
        return results.Aggregate((x, y) => x + y);
    }
}
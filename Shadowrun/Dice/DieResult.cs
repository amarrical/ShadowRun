namespace Shadowrun.Dice;

public class DieResult
{
    public int Hits { get; set; }

    public int Ones { get; set; }

    public DieResult()
    {
    }

    public DieResult(int hits, int ones)
    {
        Hits = hits;
        Ones = ones;
    }

    public static DieResult operator +(DieResult d1, DieResult d2)
    {
        return new DieResult(d1.Hits + d2.Hits, d1.Ones + d2.Ones);
    }
}
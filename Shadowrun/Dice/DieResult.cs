namespace Shadowrun.Dice;

public record DieResult(int Hits, int Ones)
{
    public int Hits { get; set; } = Hits;

    public int Ones { get; set; } = Ones;

    public static DieResult operator +(DieResult d1, DieResult d2)
    {
        return new DieResult(d1.Hits + d2.Hits, d1.Ones + d2.Ones);
    }
}
namespace Shadowrun;

public class Rng : IRng
{
    private Random random = new Random(Guid.NewGuid().GetHashCode());

    public int Next(int min, int max)
    {
        var roll = random.Next(min, max + 1);
        Console.WriteLine($"Rolled: {roll}");
        return roll;
    }
}
namespace Shadowrun.Dice;

using Results;

public interface IDice
{
    TestResult Test(int limit, Threshold threshold);
}
using Shadowrun.Dice;

namespace Shadowrun.tests.Stubs;

public class StubRng : IRng
{
    private readonly Sequence sequence;

    public StubRng(Sequence? sequence = null)
    {
        this.sequence = sequence ?? new Sequence();
    }

    public void SetSequence(params int[] init)
    {
        this.sequence.SetSequence(init);
    }


    public int Next(int min, int max)
    {
        return sequence.Next();
    }
}
using Shadowrun.Dice;

namespace Shadowrun.tests.Stubs;

using Shadowrun.Dice.Factories;

public class StubDieFactory : IDieFactory
{
    private readonly Sequence sequence;

    public StubDieFactory(Sequence? sequence = null)
    {
        this.sequence = sequence ?? new Sequence();
    }

    public void SetSequence(params int[] init) => this.sequence.SetSequence(init);

    public IDice GenerateDice(int dieCount, bool usingEdge)
    {
        var rng = new StubRng(this.sequence);
        var dice = Enumerable.Range(1, dieCount).Select(i => usingEdge ? (IDie)new EdgeDie(rng) : new Die(rng)).ToList();
        return usingEdge
            ? new EdgeDice(dice)
            : new StandardDice(dice);
    }
}
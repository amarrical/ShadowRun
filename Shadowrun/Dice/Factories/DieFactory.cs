namespace Shadowrun.Dice.Factories;

using Dice;

public class DieFactory : IDieFactory
{
    public ICollection<IDie> GenerateDice(int dieCount, bool usingEdge)
    {
        return Enumerable.Range(1, dieCount).Select(i => usingEdge ? (IDie)new EdgeDie() : new Die()).ToList();
    }
}
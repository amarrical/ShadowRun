using Shadowrun.Dice;

namespace Shadowrun.Dice.Factories;

public interface IDieFactory
{
    ICollection<IDie> GenerateDice(int dieCount, bool usingEdge);
}
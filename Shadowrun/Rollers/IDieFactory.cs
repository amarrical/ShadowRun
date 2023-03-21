using Shadowrun.Dice;

namespace Shadowrun.Rollers;

public interface IDieFactory
{
    ICollection<IDie> GenerateDice(int dieCount, bool usingEdge);
}
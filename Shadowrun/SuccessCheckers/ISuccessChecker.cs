using Shadowrun.Results;

namespace Shadowrun.SuccessCheckers;

public interface ISuccessChecker
{
    RollResult CheckSuccess(int dieCount, bool usingEdge);
}
﻿namespace Shadowrun.Rollers;

public interface IRoller
{
    RollResult CheckSuccess(int dieCount, int threshold, bool usingEdge);
}
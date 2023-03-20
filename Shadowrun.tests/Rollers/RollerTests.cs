using FluentAssertions;
using Shadowrun.tests.Stubs;

namespace Shadowrun.tests.Rollers;

public class RollerTests
{
    private Sequence sequence;
    private StubDieFactory factory;

    private Roller target;

    [SetUp]
    public void SetUp()
    {
        sequence = new Sequence();
        factory = new StubDieFactory(sequence);

        target = new Roller(factory);
    }

    [Test]
    public void CriticalGlitchOnFailureWithMoreThanHalfDiceBeingOne()
    {
        sequence.SetSequence(1);

        var result = target.CheckSuccess(1, 1, false);

        result.OverallResult.Should().Be(RollResult.Result.CriticalGlitch);
    }

    [Test]
    public void CriticalGlitchOnFailureWithMoreThanHalfDiceBeingOneWith3Dice()
    {
        sequence.SetSequence(1, 1, 4);

        var result = target.CheckSuccess(3, 1, false);

        result.OverallResult.Should().Be(RollResult.Result.CriticalGlitch);
    }

    [Test]
    public void SimpleFailureIfLessThanHalfDiceAreOneWith3Dice()
    {
        sequence.SetSequence(1, 3, 4);

        var result = target.CheckSuccess(3, 1, false);

        result.OverallResult.Should().Be(RollResult.Result.Failure);
    }
}
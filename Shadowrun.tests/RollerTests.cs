using FluentAssertions;
using Shadowrun.tests.Stubs;

namespace Shadowrun.tests;

public class RollerTests
{
    private Sequence sequence;
    private StubDieFactory factory;

    private Roller target;

    [SetUp]
    public void SetUp()
    {
        this.sequence = new Sequence();
        this.factory = new StubDieFactory(this.sequence);

        this.target = new Roller(this.factory);
    }

    [Test]
    public void CriticalGlitchOnFailureWithMoreThanHalfDiceBeingOne()
    {
        this.sequence.SetSequence(1);

        var result = this.target.CheckSuccess(1, 1, false);

        result.OverallResult.Should().Be(RollResult.Result.CriticalGlitch);
    }

    [Test]
    public void CriticalGlitchOnFailureWithMoreThanHalfDiceBeingOneWith3Dice()
    {
        this.sequence.SetSequence(1, 1, 4);

        var result = this.target.CheckSuccess(3, 1, false);

        result.OverallResult.Should().Be(RollResult.Result.CriticalGlitch);
    }

    [Test]
    public void SimpleFailureIfLessThanHalfDiceAreOneWith3Dice()
    {
        this.sequence.SetSequence(1, 3, 4);

        var result = this.target.CheckSuccess(3, 1, false);

        result.OverallResult.Should().Be(RollResult.Result.Failure);
    }
}
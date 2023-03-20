using FluentAssertions;
using Shadowrun.Dice;
using Shadowrun.tests.Stubs;

namespace Shadowrun.tests;

public class DieTests
{
    private StubRng rng;

    private Die target;

    [SetUp]
    public void Setup()
    {
        this.rng = new StubRng();

        this.target = new Die(this.rng);
    }

    [Test]
    public void LowValuesDoNotScoreHit()
    {
        this.rng.SetSequence(1, 2, 3, 4);
        target.RollHits().Should().Be(0);
        target.RollHits().Should().Be(0);
        target.RollHits().Should().Be(0);
        target.RollHits().Should().Be(0);
    }

    [Test]
    public void RollsAbove5ShouldScoreHit()
    {
        this.rng.SetSequence(4, 5, 6);
        target.RollHits().Should().Be(0);
        target.RollHits().Should().Be(1);
        target.RollHits().Should().Be(1);
    }

    [Test]
    public void RollsAt6DoNotScoreMultipleHits()
    {
        this.rng.SetSequence(6, 6, 6, 6);
        target.RollHits().Should().Be(1);
        target.RollHits().Should().Be(1);
        target.RollHits().Should().Be(1);
        target.RollHits().Should().Be(1);
    }
}
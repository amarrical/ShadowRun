using FluentAssertions;
using Shadowrun.Dice;
using Shadowrun.tests.Stubs;

namespace Shadowrun.tests.Dice;

public class DieTests
{
    private StubRng rng;

    private Die target;

    [SetUp]
    public void Setup()
    {
        rng = new StubRng();

        target = new Die(rng);
    }

    [Test]
    public void LowValuesDoNotScoreHit()
    {
        rng.SetSequence(1, 2, 3, 4);
        target.RollHits().Hits.Should().Be(0);
        target.RollHits().Hits.Should().Be(0);
        target.RollHits().Hits.Should().Be(0);
        target.RollHits().Hits.Should().Be(0);
    }

    [Test]
    public void RollsAbove5ShouldScoreHit()
    {
        rng.SetSequence(4, 5, 6);
        target.RollHits().Hits.Should().Be(0);
        target.RollHits().Hits.Should().Be(1);
        target.RollHits().Hits.Should().Be(1);
    }

    [Test]
    public void RollsAt6DoNotScoreMultipleHits()
    {
        rng.SetSequence(6, 6, 6, 6);
        target.RollHits().Hits.Should().Be(1);
        target.RollHits().Hits.Should().Be(1);
        target.RollHits().Hits.Should().Be(1);
        target.RollHits().Hits.Should().Be(1);
    }
}
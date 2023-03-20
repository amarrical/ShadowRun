using FluentAssertions;
using Shadowrun.Dice;
using Shadowrun.tests.Stubs;

namespace Shadowrun.tests.Dice
{
    public class EdgeDieTests
    {
        private StubRng rng;

        private EdgeDie target;

        [SetUp]
        public void Setup()
        {
            rng = new StubRng();

            target = new EdgeDie(rng);
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
            rng.SetSequence(4, 5, 6, 1);
            target.RollHits().Hits.Should().Be(0);
            target.RollHits().Hits.Should().Be(1);
            target.RollHits().Hits.Should().Be(1);
        }

        [Test]
        public void RollsAt6CanScoreMultipleHits()
        {
            rng.SetSequence(6, 5, 6, 6, 5);
            target.RollHits().Hits.Should().Be(2);
            target.RollHits().Hits.Should().Be(3);
        }
    }
}
using FluentAssertions;
using Shadowrun.Dice;
using Shadowrun.tests.Stubs;

namespace Shadowrun.tests
{
    public class EdgeDieTests
    {
        private StubRng rng;

        private EdgeDie target;

        [SetUp]
        public void Setup()
        {
            this.rng = new StubRng();

            this.target = new EdgeDie(this.rng);
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
            this.rng.SetSequence(4, 5, 6, 1);
            target.RollHits().Should().Be(0);
            target.RollHits().Should().Be(1);
            target.RollHits().Should().Be(1);
        }

        [Test]
        public void RollsAt6CanScoreMultipleHits()
        {
            this.rng.SetSequence(6, 5, 6, 6, 5);
            target.RollHits().Should().Be(2);
            target.RollHits().Should().Be(3);
        }
    }
}
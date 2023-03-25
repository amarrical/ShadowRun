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
            this.rng = new StubRng();

            this.target = new EdgeDie(this.rng);
        }

        [Test]
        public void LowValuesDoNotScoreHit()
        {
            this.rng.SetSequence(1, 2, 3, 4);
            this.target.Roll().Hits.Should().Be(0);
            this.target.Roll().Hits.Should().Be(0);
            this.target.Roll().Hits.Should().Be(0);
            this.target.Roll().Hits.Should().Be(0);
        }

        [Test]
        public void RollsAbove5ShouldScoreHit()
        {
            this.rng.SetSequence(4, 5, 6, 1);
            this.target.Roll().Hits.Should().Be(0);
            this.target.Roll().Hits.Should().Be(1);
            this.target.Roll().Hits.Should().Be(1);
        }

        [Test]
        public void RollsAt6CanScoreMultipleHits()
        {
            this.rng.SetSequence(6, 5, 6, 6, 5);
            this.target.Roll().Hits.Should().Be(2);
            this.target.Roll().Hits.Should().Be(3);
        }
    }
}
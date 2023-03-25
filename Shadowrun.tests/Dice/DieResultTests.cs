namespace Shadowrun.tests.Dice;

using FluentAssertions;
using Results;

public class DieResultTests
{
    [Test]
    public void DiceCanAdd()
    {
        var d1 = new DieResult(4, 1);
        var d2 = new DieResult(7, 5);

        var result = d1 + d2;

        result.Hits.Should().Be(d1.Hits + d2.Hits);
        result.Ones.Should().Be(d1.Ones + d2.Ones);
    }

    //[Test]
    //public void SuccessCalculateCorrectly()
    //{
    //    const Threshold threshold = Threshold.Extreme;
    //    var failure = new DieResult((int)threshold - 1, 0, 0);
    //    var success1 = new DieResult((int)threshold, 0, 0);
    //    var success2 = new DieResult((int)threshold + 1, 0, 0);

    //    failure.Success(threshold).Should().BeFalse();
    //    success1.Success(threshold).Should().BeTrue();
    //    success2.Success(threshold).Should().BeTrue();
    //}

    //[Test]
    //public void GlitchCalculatesCorrectly()
    //{
    //    var glitch1 = new DieResult(0, 2);
    //    var glitch2 = new DieResult(0, 2);
    //    var safe1 = new DieResult(0, 2);
    //    var safe2 = new DieResult(0, 2);

    //    glitch1.Glitch().Should().BeTrue();
    //    glitch2.Glitch().Should().BeTrue();
    //    safe1.Glitch().Should().BeFalse();
    //    safe2.Glitch().Should().BeFalse();
    //}

    //[TestCase(0, 0)]
    //[TestCase(1, 0)]
    //[TestCase(2, 0)]
    //[TestCase(3, 1)]
    //[TestCase(4, 2)]
    //[TestCase(5, 4)]
    //public void NetHitsCalculatesCorrectlyAgainstAverageThreshold(int hits, int expectedNetHits)
    //{
    //    const Threshold threshold = Threshold.Average;
    //    var dieResult = new DieResult(hits, 0, 0);

    //    dieResult.Result(threshold).NetHits.Should().Be(expectedNetHits);
    //}

    //[Test]
    //public void RollResultCalculatesCorrectly()
    //{
    //    const Threshold threshold = Threshold.Average;

    //    var criticalGlitch = new DieResult(1, 2);
    //    var failure = new DieResult(1, 1);
    //    var glitch = new DieResult(2, 2);
    //    var success = new DieResult(2, 1);

    //    criticalGlitch.Result(threshold).ResultType.Should().Be(ResultType.CriticalGlitch);
    //    failure.Result(threshold).ResultType.Should().Be(ResultType.Failure);
    //    glitch.Result(threshold).ResultType.Should().Be(ResultType.Glitch);
    //    success.Result(threshold).ResultType.Should().Be(ResultType.Success);
    //}
}
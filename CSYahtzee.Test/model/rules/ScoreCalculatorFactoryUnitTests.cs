using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using CSYahtzee.model.rules;
using CSYahtzee.model.rules.calculators;

using Xunit;

namespace CSYahtzee.Tests.model.rules
{
  public class ScoreCalculatorFactoryUnitTests
  {
    private ScoreCalculatorFactory sut;

    // It is our Theory that this Theory is a good one.
    [Theory]
    [InlineData(ScoreCategory.Aces, typeof(AcesCalculator))]
    [InlineData(ScoreCategory.Twos, typeof(TwosCalculator))]
    [InlineData(ScoreCategory.Threes, typeof(ThreesCalculator))]
    public void ShouldReturnACalculatorBasedOnEnum(ScoreCategory a_scoreCategory, Type a_type)
    {
      sut = new ScoreCalculatorFactory();
      IScoreCalculator actual = sut.GetScoreCalculator(a_scoreCategory);
      Assert.True(actual.GetType() == a_type);
    }
  }
}

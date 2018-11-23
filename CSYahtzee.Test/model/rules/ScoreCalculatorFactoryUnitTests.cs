using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using CSYahtzee.model.rules;
using CSYahtzee.model.rules.calculators;

using Moq;
using Xunit;

namespace CSYahtzee.Tests.model.rules
{
  public class ScoreCalculatorFactoryUnitTests
  {
    private ScoreCalculatorFactory sut;

    [Theory]
    [InlineData(ScoreCategory.Aces, typeof(AcesCalculator))]
    [InlineData(ScoreCategory.Aces, typeof(TwosCalculator))]
    public void ShouldReturnACalculatorBasedOnEnum(ScoreCategory a_scoreCategory, Type a_type)
    {
      sut = new ScoreCalculatorFactory();
      IScoreCalculator actual = sut.GetScoreCalculator(a_scoreCategory);
      Assert.True(actual.GetType() == a_type);
    }
  }
}

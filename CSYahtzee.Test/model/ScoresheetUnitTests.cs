using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;

using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class ScoresheetUnitTests
  {
    private Scoresheet sut;

    [Fact]
    public void ConstructorShouldThrowNullArgumentExceptionIfNotGivenAScoreFactory()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new Scoresheet(null);
      });
    }

    [Fact]
    public void RegisterScoreShouldThrowWhenNotGivenAPlayer()
    {
      sut = new Scoresheet(MockedFactory.Object);
    
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut.RegisterScore(null, ScoreCategory.Aces, new List<int> { 1, 1, 1, 1, 1 });
      });
    }

    [Fact]
    public void GetScoreShouldShouldThrowWhenNotGivenAPlayer()
    {
      sut = new Scoresheet(MockedFactory.Object);

      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut.GetScore(null, ScoreCategory.Aces);
      });
    }

    private Mock<CSYahtzee.model.rules.IScoreCalculatorFactory> MockedFactory
    {
      get
      {
        var mockedFactory = new Mock<CSYahtzee.model.rules.IScoreCalculatorFactory>();

        return mockedFactory;
      }
    }
  }
}

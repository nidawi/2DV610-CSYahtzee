using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

    [Fact]
    public void GetScoreShouldShouldReturnAScoreCategoryObject()
    {
      /*
       * We realize that we are "testing" another class here that we have not mocked.
       * The reason for this is that we cannot in a clean way mock an internal class being returned.
       * We could mock the sut and change the return type, but then we're no longer testing the sut.
       * We could add a factory creating CategoryScores, but then how do we test that factory? 
       * Then the factory itself will need a factory, and that factory will need its own factory, and you see where this is going.
       * We also believe that the class CategoryScore is rather trivial (e.g. it has no methods) which helps justify this approach.
       */

      sut = new Scoresheet(MockedFactory.Object);

      CategoryScore expected = new CategoryScore(ScoreCategory.Aces);
      expected.Set(25, new List<int>() { 1, 1, 1, 1, 1 });

      IPlayer player = MockedPlayerFactory.Object;

      sut.RegisterScore(player, ScoreCategory.Aces, new List<int> { 1, 1, 1, 1, 1 });

      CategoryScore actual = sut.GetScore(player, ScoreCategory.Aces);

      // TODO: probably refactor this Assert-statement.
      Assert.True(expected.Category == actual.Category &&
        expected.FaceValues[0] == actual.FaceValues[0] &&
        expected.FaceValues[1] == actual.FaceValues[1] &&
        expected.FaceValues[2] == actual.FaceValues[2] &&
        expected.FaceValues[3] == actual.FaceValues[3] &&
        expected.FaceValues[4] == actual.FaceValues[4] &&
        expected.Score == actual.Score
      );
    }

    private Mock<CSYahtzee.model.rules.IScoreCalculator> MockedCalculator
    {
      get
      {
        var mockedCalculator = new Mock<CSYahtzee.model.rules.IScoreCalculator>();
        mockedCalculator.Setup(c => c.CalculateScore(It.IsAny<IReadOnlyList<int>>())).Returns(25);

        return mockedCalculator;
      }
    }

    private Mock<CSYahtzee.model.rules.IScoreCalculatorFactory> MockedFactory
    {
      get
      {
        var mockedFactory = new Mock<CSYahtzee.model.rules.IScoreCalculatorFactory>();
        mockedFactory.Setup(f => f.GetScoreCalculator(It.IsAny<ScoreCategory>())).Returns(MockedCalculator.Object);

        return mockedFactory;
      }
    }

    private Mock<CSYahtzee.model.IPlayer> MockedPlayerFactory
    {
      get
      {
        var mockedPlayer = new Mock<CSYahtzee.model.IPlayer>();

        return mockedPlayer;
      }
    }
  }
}

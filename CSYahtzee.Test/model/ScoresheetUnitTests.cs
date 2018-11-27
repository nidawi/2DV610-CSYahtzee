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

    private int m_defaultScore = 25;

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

      List<int> faceValues = new List<int>() { 1, 1, 1, 1, 1 };
      CategoryScore expected = BuildCategoryScore(ScoreCategory.Aces, m_defaultScore, faceValues);

      IPlayer player = MockedPlayerFactory.Object;

      sut.RegisterScore(player, ScoreCategory.Aces, faceValues);

      CategoryScore actual = sut.GetScore(player, ScoreCategory.Aces);

      Assert.True(CategoryScoresEqual(expected, actual));
    }

    [Fact]
    public void GetScoreShouldShouldReturnMultipleScoreCategoryObjects()
    {
      sut = new Scoresheet(MockedFactory.Object);

      List<int> faceValues1 = new List<int>() { 1, 1, 1, 1, 1 };
      CategoryScore expected1 = BuildCategoryScore(ScoreCategory.Aces, m_defaultScore, faceValues1);

      List<int> faceValues2 = new List<int>() { 2, 2, 2, 2, 2 };
      CategoryScore expected2 = BuildCategoryScore(ScoreCategory.Twos, m_defaultScore, faceValues2);

      IPlayer player = MockedPlayerFactory.Object;

      sut.RegisterScore(player, ScoreCategory.Aces, faceValues1);
      sut.RegisterScore(player, ScoreCategory.Twos, faceValues2);

      CategoryScore actual1 = sut.GetScore(player, ScoreCategory.Aces);
      CategoryScore actual2 = sut.GetScore(player, ScoreCategory.Twos);

      Assert.True(CategoryScoresEqual(expected1, actual1) && CategoryScoresEqual(expected2, actual2));
    }

    // Helper methods

    private bool CategoryScoresEqual(CategoryScore a_expected, CategoryScore a_actual)
    {
      bool hasSameFaceValues = Enumerable.SequenceEqual(a_expected.FaceValues, a_actual.FaceValues);
      bool hasSameCategory = a_expected.Category == a_actual.Category;
      bool hasSameScore = a_expected.Score == a_actual.Score;

      return hasSameFaceValues && hasSameCategory && hasSameScore;
    }

    private CategoryScore BuildCategoryScore(ScoreCategory a_scoreCategory, int a_score, List<int> a_faceValues)
    {
      CategoryScore categoryScore = new CategoryScore(a_scoreCategory);
      categoryScore.Set(a_score, a_faceValues);
      return categoryScore;
    }

    // Factories

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

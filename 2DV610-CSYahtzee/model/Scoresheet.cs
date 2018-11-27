using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public enum ScoreCategory
  {
    // Upper section
    Aces,
    Twos,
    Threes,
    Fours,
    Fives,
    Sixes,

    // Lower section
    ThreeOfAKind,
    FourOfAKind,
    FullHouse,
    SmallStraight,
    LargeStraight,
    Yahtzee,
    Chance
  }

  public class Scoresheet : IScoresheet
  {
    private Dictionary<IPlayer, Dictionary<ScoreCategory, CategoryScore>> m_playerScores;
    private rules.IScoreCalculatorFactory m_scoreFactory;

    public Scoresheet(rules.IScoreCalculatorFactory a_scoreFactory)
    {
      if (a_scoreFactory == null)
        throw new ArgumentNullException();

      m_playerScores = new Dictionary<IPlayer, Dictionary<ScoreCategory, CategoryScore>>();
      m_scoreFactory = a_scoreFactory;
    }

    public void RegisterScore(IPlayer a_player, ScoreCategory a_scoreCatagory, List<int> a_faceValues)
    {
      if (a_player == null)
        throw new ArgumentNullException();

      CategoryScore categoryScore = new CategoryScore(a_scoreCatagory);
      int score = m_scoreFactory.GetScoreCalculator(a_scoreCatagory).CalculateScore(a_faceValues);
      categoryScore.Set(score, a_faceValues);

      Dictionary<ScoreCategory, CategoryScore> playerScore = new Dictionary<ScoreCategory, CategoryScore>();
      playerScore.Add(a_scoreCatagory, categoryScore);

      m_playerScores.Add(a_player, playerScore);
    }

    public CategoryScore GetScore(IPlayer a_player, ScoreCategory a_scoreCatagory)
    {
      if (a_player == null)
        throw new ArgumentNullException();

      // TODO: Error handling.
      var score = GetPlayerScore(a_player)
        .Where(e => e.Key == a_scoreCatagory)
        .Select(e => e.Value)
        .First();

      return score;
    }

    private Dictionary<ScoreCategory, CategoryScore> GetPlayerScore(IPlayer a_player)
    {
      // TODO: Error handling.
      var scoreDic = m_playerScores
       .Where(a => a.Key == a_player)
       .Select(e => e.Value)
       .First();

      return scoreDic;
    }

  }
}

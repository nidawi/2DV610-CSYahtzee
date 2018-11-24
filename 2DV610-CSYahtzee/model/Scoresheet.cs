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

    public Scoresheet(rules.IScoreCalculatorFactory a_scoreFactory)
    {
      if (a_scoreFactory == null)
        throw new ArgumentNullException();
    }

    public void RegisterScore(IPlayer a_player, ScoreCategory a_scoreCatagory, List<int> a_faceValues)
    {
      if (a_player == null) 
        throw new ArgumentNullException();
    }

    public CategoryScore GetScore(IPlayer a_player, ScoreCategory a_scoreCatagory)
    {
      throw new NotImplementedException();
    }

  }
}

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
    FourOfAKind
  }

  public class Scoresheet : IScoresheet
  {
    public Scoresheet(rules.IScoreCalculatorFactory a_scoreFactory)
    {
      if (a_scoreFactory == null)
        throw new ArgumentNullException();
    }
  }
}

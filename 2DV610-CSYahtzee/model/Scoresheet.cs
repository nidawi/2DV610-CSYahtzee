using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public enum ScoreCategory
  {
    Aces,
    Twos,
    Threes,
    Fours,
    Fives,
    Sixes
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

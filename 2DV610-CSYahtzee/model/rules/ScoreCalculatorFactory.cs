using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSYahtzee.model.rules.calculators;

namespace CSYahtzee.model.rules
{
  public class ScoreCalculatorFactory : IScoreCalculatorFactory
  {
    /// <summary>
    /// Creates and returns a Score Calculator.
    /// </summary>
    /// <param name="a_scoreCategory">Which calculator the factory should manufacture. (Get it? It's a factory)</param>
    /// <returns>a Score Calculator.</returns>
    public IScoreCalculator GetScoreCalculator(ScoreCategory a_scoreCategory)
    {
      switch (a_scoreCategory)
      {
        case ScoreCategory.Aces:
          return new AcesCalculator();
        case ScoreCategory.Twos:
          return new TwosCalculator();
      }

      if (a_scoreCategory == ScoreCategory.Threes)
        return new ThreesCalculator();

      throw new NotImplementedException();
    }
  }
}

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
      // Like C Martin said, Switches are ugly, but they're OK in a Factory.
      switch (a_scoreCategory)
      {
        case ScoreCategory.Aces:
          return new AcesCalculator();
        case ScoreCategory.Twos:
          return new TwosCalculator();
        case ScoreCategory.Threes:
          return new ThreesCalculator();
        case ScoreCategory.Fours:
          return new FoursCalculator();
        case ScoreCategory.Fives:
          return new FivesCalculator();
        case ScoreCategory.Sixes:
          return new SixesCalculator();
        case ScoreCategory.ThreeOfAKind:
          return new ThreeOfAKindCalculator();
        case ScoreCategory.FourOfAKind:
          return new FourOfAKindCalculator();
        case ScoreCategory.FullHouse:
          return new FullHouseCalculator();
        case ScoreCategory.SmallStraight:
          return new SmallStraightCalculator();
        case ScoreCategory.LargeStraight:
          return new LargeStraightCalculator();
        case ScoreCategory.Yahtzee:
          return new YahtzeeCalculator();
        case ScoreCategory.Chance:
          return new ChanceCalculator();
        default:
          throw new ArgumentException();
      }
    }
  }
}

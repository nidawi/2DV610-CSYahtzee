using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  /// <summary>
  /// Yahtzee Game Facade
  /// </summary>
  public class Yahtzee : IYahtzee
  {
    public Yahtzee(rules.IPlayerFactory a_playerFactory, rules.IYahtzeeGameRulesAbstractFactory a_ruleFactory)
    {
      if (a_playerFactory == null || a_ruleFactory == null)
      {
        throw new ArgumentNullException();
      }
    }
  }
}

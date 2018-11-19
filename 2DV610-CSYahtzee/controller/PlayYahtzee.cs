using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.controller
{
  public class PlayYahtzee
  {
    public PlayYahtzee(model.rules.IPlayerFactory a_playerFactory, model.rules.IYahtzeeGameRulesAbstractFactory a_ruleFactory)
    {
      if (a_playerFactory == null || a_ruleFactory == null)
      {
        throw new ArgumentNullException();
      }
    }
  }
}

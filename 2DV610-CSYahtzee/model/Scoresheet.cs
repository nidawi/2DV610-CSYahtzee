using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class Scoresheet : IScoresheet
  {
    public Scoresheet(rules.IYahtzeeGameRulesAbstractFactory a_ruleFactory)
    {
      if (a_ruleFactory == null) throw new ArgumentNullException();
    }
  }
}

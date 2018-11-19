using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.controller
{
  public class PlayYahtzee
  {

    public PlayYahtzee(view.IConsole console, model.IYahtzee yahtzee)
    {
      if (yahtzee == null)
      {
        throw new ArgumentNullException();
      }

      throw new NotImplementedException();
    }

  }
}

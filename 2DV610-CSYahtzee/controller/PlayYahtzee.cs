using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.controller
{
  public class PlayYahtzee
  {

    public PlayYahtzee(view.IConsole a_console, model.IYahtzee a_yahtzee)
    {
      if (a_yahtzee == null || a_console == null)
        throw new ArgumentNullException();
    }

    public bool PlayGame()
    {
      throw new NotImplementedException();
    }
  }
}

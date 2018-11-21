using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.controller
{
  public class PlayYahtzee
  {

    private view.IConsole m_console;

    public PlayYahtzee(view.IConsole a_console, model.IYahtzee a_yahtzee)
    {
      if (a_yahtzee == null || a_console == null)
        throw new ArgumentNullException();

      m_console = a_console;
    }

    public bool PlayGame()
    {
      // New Game Here

      // Welcome Message 
      // Instructions

      m_console.DisplayWelcomeMessage();

      m_console.DisplayPlayerCountPrompt();

  
      
      // Add Players
      // Loop Through Players

      // Begin Game Loop
      return false;
    }
  }
}

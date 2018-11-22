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
    private model.IYahtzee m_game;

    public PlayYahtzee(view.IConsole a_console, model.IYahtzee a_yahtzee)
    {
      if (a_yahtzee == null || a_console == null)
        throw new ArgumentNullException();

      m_console = a_console;
      m_game = a_yahtzee;
    }

    public bool PlayGame()
    {
      // New Game Here

      // Welcome Message 
      // Instructions

      m_console.DisplayWelcomeMessage();

      m_console.DisplayPlayerCountPrompt();

      int playerCount = m_console.GetInputInteger(); // handle errors?
      for (int i = 0; i < playerCount; i++)
      {

        m_console.DisplayPlayernamePrompt();

        m_game.AddPlayer($"Player{(i + 1).ToString()}");
      }

      // Add Players
      // Loop Through Players

      // Begin Game Loop
      return false;
    }
  }
}

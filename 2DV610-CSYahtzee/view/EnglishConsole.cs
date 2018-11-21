using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.view
{
  public class EnglishConsole : IConsole
  {
    // Output methods 

    public void DisplayPlayernamePrompt()
    {
      Console.Write("Please provide a player name: ");
    }

    public void DisplayWelcomeMessage()
    {
      Console.WriteLine("Welcome to GROOVEH YAHTZEE! Input coin to continue.");
    }

    public void DisplayPlayerCountPrompt()
    {
      Console.Write("How many will be playing? ");
    }

    // Input methods

    public string GetInputString()
    {
      string input = Console.ReadLine();
      return input;
    }
  }
}

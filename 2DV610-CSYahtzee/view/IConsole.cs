using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.view
{
  public interface IConsole
  {

    // Output methods

    void DisplayPlayernamePrompt();

    void DisplayWelcomeMessage();

    void DisplayPlayerCountPrompt();

    // Input methods

    string GetInputString();
  }
}

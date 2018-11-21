using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.view
{
  public interface IConsole
  {
    void DisplayPlayernamePrompt();

    void DisplayWelcomeMessage();

    void DisplayPlayerCountPrompt();

    string GetInputString();
  }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.view
{
  public class EnglishConsole : IConsole
  {
    public void DisplayPlayernamePrompt()
    {
      Console.WriteLine("Please provide a player name: ");
    }
  }
}

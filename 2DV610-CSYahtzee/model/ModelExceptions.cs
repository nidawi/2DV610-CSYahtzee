﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class DieNotRolledException : Exception { }
  public class InvalidDiceCountException : Exception { }
  public class PlayernameTooShortException : Exception { }
}

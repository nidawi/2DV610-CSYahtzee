﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model.rules
{
  public interface IScoreCalculator
  {
    int CalculateScore(IReadOnlyList<int> a_faceValues);
  }
}

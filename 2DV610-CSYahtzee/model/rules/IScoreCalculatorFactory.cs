﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model.rules
{
  public interface IScoreCalculatorFactory
  {
    IScoreCalculator GetScoreCalculator(ScoreCategory a_scoreCategory);
  }
}

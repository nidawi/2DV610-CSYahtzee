﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSYahtzee.model.rules.calculators;

namespace CSYahtzee.model.rules
{
  public class ScoreCalculatorFactory : IScoreCalculatorFactory
  {
    public IScoreCalculator GetScoreCalculator(ScoreCategory a_scoreCategory)
    {
      if (a_scoreCategory == ScoreCategory.Aces)
        return new AcesCalculator();

      throw new NotImplementedException();
    }
  }
}

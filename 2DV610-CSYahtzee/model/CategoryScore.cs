﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class CategoryScore
  {
    private ScoreCategory m_scoreCategory;

    public ScoreCategory Category => m_scoreCategory;

    public CategoryScore(ScoreCategory a_scoreCategory)
    {
      m_scoreCategory = a_scoreCategory;
    }

  }
}

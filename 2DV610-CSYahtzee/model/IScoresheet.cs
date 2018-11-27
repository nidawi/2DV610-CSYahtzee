using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public interface IScoresheet
  {
    CategoryScore GetScore(IPlayer a_player, ScoreCategory a_scoreCatagory);
  }
}

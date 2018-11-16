using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public interface IDiceCup
  {
    int DiceCount
    {
      get;
    }

    bool HasRolled
    {
      get;
    }

    IReadOnlyList<int> DiceFaceValues
    {
      get;
    }

  }
}

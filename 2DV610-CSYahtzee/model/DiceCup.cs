using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class DiceCup
  {
    private List<Die> d;

    public DiceCup(int c)
    {
      d = new List<Die>();
      for (int i = 0; i < c; i++)
        d.Add(new Die());
    }
  }
}

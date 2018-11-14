using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class DiceCup
  {
    private List<Die> m_dice;

    public int DiceCount
    {
      get
      {
        int sum = 0;
        for (int i = 0; i < m_dice.Count; i++)
        {
          sum++;
        }
        return sum;
      }
      protected set
      {
        if (value < 0)
          throw new InvalidDiceCountException();

        for (int i = 0; i < value; i++)
          m_dice.Add(new Die());
      }
    }

    public DiceCup(int a_diceCount)
    {
      m_dice = new List<Die>();
      DiceCount = a_diceCount;
    }
  }
}

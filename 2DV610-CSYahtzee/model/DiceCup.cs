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
      get => throw new NotImplementedException();
      protected set
      {
        if (value < 0) throw new InvalidDiceCountException();

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

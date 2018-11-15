using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class DiceCup : IDiceCup
  {
    private List<IDie> m_dice;

    public int DiceCount
    {
      get => m_dice.Count;
      protected set
      {
        if (value < 0)
          throw new InvalidDiceCountException();

        for (int i = 0; i < value; i++)
          m_dice.Add(new Die());
      }
    }

    public IReadOnlyList<int> DiceFaceValues
    {
      get => throw new NotImplementedException();
    }

    public DiceCup(int a_diceCount)
    {
      m_dice = new List<IDie>();
      DiceCount = a_diceCount;
    }


  }
}

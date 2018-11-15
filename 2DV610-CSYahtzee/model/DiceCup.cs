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
    private rules.IDieFactory m_dieFactory;

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

    public DiceCup(int a_diceCount, rules.IDieFactory a_dieFactory)
    {
      m_dice = new List<IDie>();
      DiceCount = a_diceCount;
      m_dieFactory = a_dieFactory ?? throw new ArgumentNullException();
    }

    public DiceCup(int a_diceCount) : this(a_diceCount, new rules.DieFactory())
    {

    }
  }
}

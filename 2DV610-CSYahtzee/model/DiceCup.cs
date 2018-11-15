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
          m_dice.Add(m_dieFactory.Die);
      }
    }

    public IReadOnlyList<int> DiceFaceValues
    {
      get
      {
        List<int> fvs = new List<int>();
        foreach (IDie die in m_dice)
        {
          fvs.Add(die.FaceValue);
        }
        return fvs;
      }
    }

    public DiceCup(int a_diceCount, rules.IDieFactory a_dieFactory)
    {
      m_dice = new List<IDie>();
      m_dieFactory = a_dieFactory ?? throw new ArgumentNullException();
      DiceCount = a_diceCount;
    }

    public DiceCup(int a_diceCount) : this(a_diceCount, new rules.DieFactory())
    {

    }
  }
}

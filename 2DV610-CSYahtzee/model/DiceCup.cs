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

    /// <summary>
    /// Returns the amount of dice contained in this dice cup.
    /// </summary>
    /// <exception cref="InvalidDiceCountException"></exception>
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

    /// <summary>
    /// Returns true/false depending on whether all dice in this dice cup have been rolled.
    /// </summary>
    public bool HasRolled => m_dice.All(die => die.HasRolled);

    public IReadOnlyList<int> DiceFaceValues
    {
      get => m_dice.Select(die => die.FaceValue).ToList();
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

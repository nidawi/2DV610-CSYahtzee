using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class Die : IDie
  {
    private int m_faceValue;
    private bool m_locked;
    private Random m_randomizer = null; // Random is a system class and thus not our responsibility.

    /// <summary>
    /// Returns the current value of the die.
    /// </summary>
    /// <exception cref="DieNotRolledException"></exception>
    public int FaceValue
    {
      private set => m_faceValue = value;
      get
      {
        if (m_faceValue == 0)
          throw new DieNotRolledException();

        return m_faceValue;
      }
    }

    /// <summary>
    /// Returns true/false depending on whether the die has been rolled.
    /// </summary>
    public bool HasRolled => m_faceValue > 0;

    public bool Locked
    {
      get => m_locked;
      set => m_locked = value;
    }

    /// <summary>
    /// Default construtor.
    /// </summary>
    public Die()
    {
      m_faceValue = 0;
      m_locked = false;
      m_randomizer = new Random();
    }

    /// <summary>
    /// Rolls the die and sets its face value.
    /// </summary>
    public void Roll()
    {
      FaceValue = m_randomizer.Next(1, 6);
    }
  }
}

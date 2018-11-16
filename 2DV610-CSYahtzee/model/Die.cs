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
    private Random m_randomizer = null;

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

    public bool HasRolled
    {
      get
      {
        if (m_faceValue == 0)
          return false;

        return true;
      }
    }

    /// <summary>
    /// Default construtor.
    /// </summary>
    public Die()
    {
      m_faceValue = 0;
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

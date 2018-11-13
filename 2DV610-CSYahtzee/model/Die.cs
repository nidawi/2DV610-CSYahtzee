using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class Die
  {
    private int m_faceValue;

    public int FaceValue
    {
      private set => m_faceValue = value;
      get
      {
        if (m_faceValue == 0)
        {
          throw new DieNotRolledException();
        }


        // else?


        return m_faceValue;
      }
    }

    public Die()
    {
      m_faceValue = 0;
    }

    public void Roll()
    {
      Random r = new Random();
      FaceValue = r.Next(1, 6);
    }
  }
}

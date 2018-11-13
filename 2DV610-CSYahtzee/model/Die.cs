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
      get => m_faceValue;
    }

    public Die()
    {
      m_faceValue = 0;
    }

    public void Roll()
    {
      throw new NotImplementedException();
    }
  }
}

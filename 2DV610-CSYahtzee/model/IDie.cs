using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public interface IDie
  {
    int FaceValue
    {
      get;
    }

    void Roll();
  }
}

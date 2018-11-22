using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public interface IYahtzee
  {
    int PlayerCount { get; }
    void AddPlayer(string name);
  }
}

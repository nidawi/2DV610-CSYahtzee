using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  public class Player
  {
    private string m_name;

    public const int MIN_NAME_LENGTH = 2; // Imaginary business rule.

    public string Name
    {
      get => throw new NotImplementedException();
      protected set
      {
        if (value == null)
          throw new NotImplementedException();

        if (value.Length < MIN_NAME_LENGTH)
          throw new NotImplementedException();

        m_name = value;
      }
    }

    public Player(string a_name)
    {
      Name = a_name;
    }
  }
}

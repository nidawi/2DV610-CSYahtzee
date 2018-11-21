using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSYahtzee.model
{
  /// <summary>
  /// Yahtzee Game Facade
  /// </summary>
  public class Yahtzee : IYahtzee
  {
    private List<IPlayer> m_players;

    private rules.IPlayerFactory m_playerFactory;

    public int PlayerCount => m_players.Count;

    public Yahtzee(rules.IPlayerFactory a_playerFactory, rules.IYahtzeeGameRulesAbstractFactory a_ruleFactory)
    {
      m_playerFactory = a_playerFactory;
      m_players = new List<IPlayer>();

      if (a_playerFactory == null || a_ruleFactory == null)
      {
        throw new ArgumentNullException();
      }
    }

    public void AddPlayer(string name)
    {
      m_players.Add(m_playerFactory.Player);
    }
  }
}

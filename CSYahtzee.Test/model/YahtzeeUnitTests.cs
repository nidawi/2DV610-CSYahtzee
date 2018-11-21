using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class YahtzeeUnitTests
  {
    private Yahtzee sut;

    [Fact]
    public void ConstructorShouldThrowWhenGivenNullPlayerFactory()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new Yahtzee(null, MockedGameRulesFactory);
      });
    }

    [Fact]
    public void ConstructorShouldThrowWhenGivenNullGameRulesFactory()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new Yahtzee(MockedPlayerFactory, null);
      });
    }

    [Fact]
    public void ShouldReturnDefaultPlayerCount()
    {
      sut = new Yahtzee(MockedPlayerFactory, MockedGameRulesFactory);
      Assert.Equal(0, sut.PlayerCount);
    }

    [Fact]
    public void ShouldAddAPlayer()
    {
      // This verifies that a player, any player, has been added.
      sut = new Yahtzee(MockedPlayerFactory, MockedGameRulesFactory);

      sut.AddPlayer("Niklas af Eriksson");
      sut.AddPlayer("Jonathan von Alklid");

      Assert.Equal(2, sut.PlayerCount);
    }

    private CSYahtzee.model.rules.IYahtzeeGameRulesAbstractFactory MockedGameRulesFactory
    {
      get
      {
        var mockedGameRulesFactory = new Mock<CSYahtzee.model.rules.IYahtzeeGameRulesAbstractFactory>();
        // no functionality yet

        return mockedGameRulesFactory.Object;
      }
    }

    private CSYahtzee.model.rules.IPlayerFactory MockedPlayerFactory
    {
      get
      {
        var mockedPlayer = new Mock<CSYahtzee.model.IPlayer>();

        var mockedPlayerFactory = new Mock<CSYahtzee.model.rules.IPlayerFactory>();
        mockedPlayerFactory.Setup(pf => pf.Player).Returns(mockedPlayer.Object);
        
        // no functionality yet

        return mockedPlayerFactory.Object;
      }
    }
  }
}

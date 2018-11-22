using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.controller;
using Xunit;
using Moq;

namespace CSYahtzee.Tests.controller
{
  public class PlayYahtzeeUnitTests
  {
    private PlayYahtzee sut;
    
    private int m_defaultPlayerCount = 3;

    [Fact]
    public void ConstructorShouldThrowWhenGivenNullYahtzee()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new PlayYahtzee(MockedConsole.Object, null);
      });
    }

    [Fact]
    public void ConstructorShouldThrowWhenGivenNullConsole()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new PlayYahtzee(null, MockedYahtzee.Object);
      });
    }

    [Fact]
    public void ShouldReturnFalseWhenGameLoopEnds()
    {
      sut = new PlayYahtzee(MockedConsole.Object, MockedYahtzee.Object);

      bool actual = sut.PlayGame();

      Assert.False(actual);
    }

    [Fact]
    public void ShouldPrintWelcomeMessage()
    {
      var console = MockedConsole;
      sut = new PlayYahtzee(console.Object, MockedYahtzee.Object);

      sut.PlayGame();

      console.Verify(c => c.DisplayWelcomeMessage());
    }

    [Fact]
    public void ShouldDisplayPlayerCountPrompt()
    {
      var console = MockedConsole;
      sut = new PlayYahtzee(console.Object, MockedYahtzee.Object);

      sut.PlayGame();

      console.Verify(c => c.DisplayPlayerCountPrompt());
    }

    [Fact]
    public void ShouldPrintPlayernamePromptXTimes()
    {
      var console = MockedConsole;
      console.Setup(c => c.GetInputInteger()).Returns(m_defaultPlayerCount);
      sut = new PlayYahtzee(console.Object, MockedYahtzee.Object);

      sut.PlayGame();

      console.Verify(c => c.DisplayPlayernamePrompt(), Times.Exactly(m_defaultPlayerCount));
    }

    [Fact]
    public void ShouldAddXPlayers()
    {
      var yahtzee = MockedYahtzee;
     
      sut = new PlayYahtzee(MockedConsole.Object, yahtzee.Object);

      sut.PlayGame();

      yahtzee.Verify(c => c.AddPlayer(It.IsAny<string>()), Times.Exactly(m_defaultPlayerCount));
    }

    #region Helpers
    private Mock<CSYahtzee.view.IConsole> MockedConsole
    {
      get
      {
        var mockedConsole = new Mock<CSYahtzee.view.IConsole>();
        mockedConsole.Setup(c => c.DisplayWelcomeMessage()).Verifiable();
        mockedConsole.Setup(c => c.DisplayPlayerCountPrompt()).Verifiable();
        mockedConsole.Setup(c => c.GetInputInteger()).Returns(m_defaultPlayerCount); // default might need to be overwritten if GetInputInteger is used for something else the regarding "number of players".

        return mockedConsole;
      }
    }

    private Mock<CSYahtzee.model.IYahtzee> MockedYahtzee
    {
      get
      {
        var mockedYahtzee = new Mock<CSYahtzee.model.IYahtzee>();
        mockedYahtzee.Setup(c => c.AddPlayer(It.IsAny<string>())).Verifiable();
        mockedYahtzee.SetupGet(y => y.PlayerCount).Returns(m_defaultPlayerCount);

        return mockedYahtzee;
      }
    }
    #endregion
  }
}
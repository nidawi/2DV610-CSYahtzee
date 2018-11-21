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
    public void ShouldDisplayDisplayPlayernamePromptXTimes()
    {
      var console = MockedConsole;
      sut = new PlayYahtzee(console.Object, MockedYahtzee.Object);

      sut.PlayGame();

      console.Verify(c => c.DisplayPlayernamePrompt(), Times.Exactly(3));
    }


    #region Helpers
    private Mock<CSYahtzee.view.IConsole> MockedConsole
    {
      get
      {
        var mockedConsole = new Mock<CSYahtzee.view.IConsole>();
        mockedConsole.Setup(c => c.DisplayWelcomeMessage()).Verifiable();
        mockedConsole.Setup(c => c.DisplayPlayerCountPrompt()).Verifiable();
        mockedConsole.Setup(c => c.GetInputInteger()).Returns(3);

        return mockedConsole;
      }
    }

    private Mock<CSYahtzee.model.IYahtzee> MockedYahtzee
    {
      get
      {
        var mockedYahtzee = new Mock<CSYahtzee.model.IYahtzee>();
        // no functionality yet

        return mockedYahtzee;
      }
    }
    #endregion
  }
}
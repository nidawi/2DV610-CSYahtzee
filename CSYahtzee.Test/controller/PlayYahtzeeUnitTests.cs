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
        sut = new PlayYahtzee(MockedConsole, null);
      });
    }

    [Fact]
    public void ConstructorShouldThrowWhenGivenNullConsole()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new PlayYahtzee(null, MockedYahtzee);
      });
    }

    private CSYahtzee.view.IConsole MockedConsole
    {
      get
      {
        var mockedConsole = new Mock<CSYahtzee.view.IConsole>();
        // no functionality yet

        return mockedConsole.Object;
      }
    }

    private CSYahtzee.model.IYahtzee MockedYahtzee
    {
      get
      {
        var mockedYahtzee = new Mock<CSYahtzee.model.IYahtzee>();
        // no functionality yet

        return mockedYahtzee.Object;
      }
    }
  }
}
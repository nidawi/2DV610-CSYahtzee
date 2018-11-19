using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using CSYahtzee.controller;
using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class PlayYahtzeeUnitTests
  {
    private PlayYahtzee sut;

    [Fact]
    public void ConstructorShouldThrowWhenGivenNullPlayerFactory()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new PlayYahtzee(null, MockedGameRulesFactory);
      });
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
  }
}

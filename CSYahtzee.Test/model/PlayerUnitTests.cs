using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Moq;

using CSYahtzee.model;

namespace CSYahtzee.Tests.model
{
  public class PlayerUnitTests : IDisposable
  {
    private Player sut;
    private string m_playerName = "DefaultName"; // default string is needed else constructor will throw.

    public PlayerUnitTests()
    {
      Dispose();
    }

    public void Dispose()
    {
      sut = new Player(m_playerName);
    }

    [Fact]
    public void ConstructorShouldNotThrowWithValidPlayername()
    {
      Assert.True(sut != null);
    }
  }
}

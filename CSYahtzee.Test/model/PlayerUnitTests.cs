using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using Moq;

using CSYahtzee.model;

namespace CSYahtzee.Tests.model
{
  public class PlayerUnitTests : IDisposable
  {
    private Player sut;
    private string m_playername = "DefaultName"; // default string is needed else constructor will throw.

    public PlayerUnitTests()
    {
      Dispose();
    }

    public void Dispose()
    {
      sut = new Player(m_playername);
    }

    [Fact]
    public void ConstructorShouldNotThrowWithValidPlayername()
    {
      Assert.True(sut != null);
    }

    [Fact]
    public void ConstructorShouldThrowWhenGivenNull()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new Player(null);
      });
    }

    [Fact]
    public void ConstructorShouldThrowWhenGivenTooShortString()
    {
      Assert.Throws<PlayernameTooShortException>(delegate ()
      {
        sut = new Player(new string('h', Player.MIN_NAME_LENGTH - 1));
      });
    }

    [Fact]
    public void ShouldReturnCorrectPlayername()
    {
      Assert.Equal(m_playername, sut.Name);
    }
  }
}

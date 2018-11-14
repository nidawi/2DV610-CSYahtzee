using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class DiceCupUnitTests : IDisposable
  {
    private DiceCup sut;
    private int m_diceCount = 5;

    public DiceCupUnitTests()
    {
      Dispose();
    }

    public void Dispose()
    {
      sut = new DiceCup(m_diceCount);
    }

    [Fact]
    public void ConstructorShouldNotThrowWithAcceptableInput()
    {
      Assert.True(sut != null);
    }

    [Fact]
    public void ConstructorShouldThrowWithUnacceptableInput()
    {
      Assert.Throws<InvalidDiceCountException>(delegate ()
      {
        sut = new DiceCup(-m_diceCount);
      });
    }

    [Fact]
    public void ShouldReturnCorrectDiceCount()
    {
      Assert.Equal(m_diceCount, sut.DiceCount);
    }

  }
}

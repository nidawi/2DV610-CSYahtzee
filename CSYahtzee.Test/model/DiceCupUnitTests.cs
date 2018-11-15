using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using CSYahtzee.model.rules;

using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class DiceCupUnitTests : IDisposable
  {
    private DiceCup sut;
    private int m_diceCount = 5;
    private int m_diceValue = 2;

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

    [Fact]
    public void OverloadedConstructorShouldNotThrowWithAcceptableInput()
    {
      sut = new DiceCup(m_diceCount, MockedDieFactory);
      Assert.True(sut != null);
    }

    private IDieFactory MockedDieFactory
    {
      get
      {
        var mockedDieFactory = new Mock<IDieFactory>();
        var mockedDie = new Mock<IDie>();

        mockedDie.Setup(die => die.FaceValue).Returns(m_diceValue);
        mockedDieFactory.Setup(factory => factory.Die).Returns(mockedDie.Object);

        return mockedDieFactory.Object;
      }
    }

  }
}

﻿using System;
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

    [Fact]
    public void OverloadedConstructorShouldThrowWhenNotGivenADieFactory()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new DiceCup(m_diceCount, null);
      });
    }

    [Fact]
    public void ShouldReturnAListOfFaceValues()
    {
      // No point in writing more tests for face values since it's all mocked anyway
      sut = new DiceCup(m_diceCount, MockedDieFactory);
      IReadOnlyList<int> faceValues = sut.DiceFaceValues;
      Assert.True(faceValues != null);
    }

    private IDieFactory MockedDieFactory
    {
      get
      {
        var mockedDieFactory = new Mock<IDieFactory>();
        var mockedDie = new Mock<IDie>();

        mockedDie.SetupGet(die => die.FaceValue).Returns(m_diceValue);
        mockedDieFactory.SetupGet(factory => factory.Die).Returns(mockedDie.Object);

        return mockedDieFactory.Object;
      }
    }

  }
}

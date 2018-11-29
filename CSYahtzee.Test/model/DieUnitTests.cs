using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;

using Xunit;

namespace CSYahtzee.Tests.model
{
  public class DieUnitTests : IDisposable
  {
    private Die sut;

    public DieUnitTests()
    {
      Dispose();
    }

    public void Dispose()
    {
      sut = new Die();
    }

    [Fact]
    public void DieThrowsExceptionIfNotRolled()
    {
      Assert.Throws<CSYahtzee.model.DieNotRolledException>(delegate () {
        int v = sut.FaceValue;
      });
    }

    [Fact]
    public void DieGivesFaceValueIfRolled()
    {
      sut.Roll();
      Assert.True(sut.FaceValue != 0);
    }

    [Fact]
    public void DieGivesFaceValueInRangeIfRolled()
    {
      sut.Roll();
      AssertDieHasAcceptableValue();
    }

    [Fact]
    public void DieRollStateShouldBeFalseBeforeBeingRolled()
    {
      // Die has not been rolled.
      Assert.False(sut.HasRolled);
    }

    [Fact]
    public void DieRollStateShouldBeTrueAfterBeingRolled()
    {
      // Die has been rolled.
      sut.Roll();
      Assert.True(sut.HasRolled);
    }

    [Fact]
    public void DieIsLockedShouldReturnFalsePerDefault()
    {
      bool actual = sut.Locked;

      Assert.False(actual);
    }

    [Fact]
    public void LockedDieShouldReturnTrue()
    {
      sut.Locked = true;
      bool actual = sut.Locked;

      Assert.True(actual);
    }

    // Helper methods

    private void AssertDieHasAcceptableValue()
    {
      Assert.True(sut.FaceValue >= 1 || sut.FaceValue <= 6);
    }
  }
}

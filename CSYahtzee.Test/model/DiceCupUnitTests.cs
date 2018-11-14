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

    public DiceCupUnitTests()
    {
      Dispose();
    }

    public void Dispose()
    {
      sut = new DiceCup(5);
    }

    [Fact]
    public void ConstructorShouldNotThrowWithAcceptableInput()
    {
      Assert.True(sut != null);
    }
  }
}

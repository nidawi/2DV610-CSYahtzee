﻿using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;
using CSYahtzee.model.rules;
using Xunit;
using Moq;

namespace CSYahtzee.Tests.model.rules
{
  public class DieFactoryUnitTests : IDisposable
  {
    private DieFactory sut;

    public DieFactoryUnitTests()
    {
      sut = new DieFactory();
    }

    public void Dispose()
    {
      sut = new DieFactory();
    }

    [Fact]
    public void ShouldReturnADie()
    {
      IDie die = sut.Die;
      Assert.True(die is Die);
    }
  }
}

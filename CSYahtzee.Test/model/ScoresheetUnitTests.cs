using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;

using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class ScoresheetUnitTests
  {
    private Scoresheet sut;

    [Fact]
    public void ScoreSheetShouldThrowNullArgumentExceptionIfNotGivenAScoreFactory()
    {
      Assert.Throws<ArgumentNullException>(delegate ()
      {
        sut = new Scoresheet(null);
      });
    }
  }
}

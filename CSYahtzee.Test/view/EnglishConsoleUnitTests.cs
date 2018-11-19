using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Xunit;
using Moq;

using CSYahtzee.view;

namespace CSYahtzee.Tests.view
{
  public class EnglishConsoleUnitTests : IDisposable
  {
    private EnglishConsole sut;

    private StringWriter m_testWriter;

    public EnglishConsoleUnitTests()
    {
      Dispose();
    }

    public void Dispose()
    {
      sut = new EnglishConsole();

      m_testWriter = new StringWriter();

      Console.SetOut(m_testWriter);
    }

    [Fact]
    public void ShouldDisplayPlayernamePrompt()
    {
      sut.DisplayPlayernamePrompt();
      AssertOutput("Please provide a player name: ");
    }

    private void AssertOutput(string a_actual)
    {
      string expected = m_testWriter.ToString();
      Assert.Equal(expected.Trim(), a_actual.Trim());
    }
  }
}

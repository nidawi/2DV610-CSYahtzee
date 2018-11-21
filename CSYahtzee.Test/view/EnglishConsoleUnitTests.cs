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

    // Since System.Console is static class we cannot mock it.
    // However, we can redirect console IO and analyze the results.
    private StringWriter m_testWriter;
    private StringReader m_testReader;

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

    [Fact]
    public void ShouldDisplayWelcomeMessage()
    {
      sut.DisplayWelcomeMessage();
      AssertOutput("Welcome to GROOVEH YAHTZEE! Input coin to continue.");
    }

    [Fact]
    public void ShouldReadInputString()
    {
      string expected = "Niklas af Eriksson";
      AssertInput(expected);
    }

    [Fact]
    public void ShouldDisplayPlayerCountPrompt()
    {
      sut.DisplayPlayerCountPrompt();
      AssertOutput("How many will be playing? ");
    }

    [Fact]
    public void ShouldReadInputInteger()
    {
      int expected = 3;
      AssertInput(expected);
    }

    [Fact]
    public void ReadInputIntegerShouldThrowOnInvalidInteger()
    {
      SetInput("not a number");

      Assert.Throws<FormatException>(delegate() {
        sut.GetInputInteger();
      });
    }

    private void AssertOutput(string a_actual)
    {
      string expected = m_testWriter.ToString();
      Assert.Equal(expected.Trim(), a_actual.Trim());
    }

    private void AssertInput(string a_expected)
    {
      SetInput(a_expected);

      string actual = sut.GetInputString();

      Assert.Equal(a_expected, actual);
    }

    private void AssertInput(int a_expected)
    {
      SetInput(a_expected.ToString());

      int actual = sut.GetInputInteger();

      Assert.Equal(a_expected, actual);
    }

    private void SetInput(string a_input)
    {
      m_testReader = new StringReader(a_input);
      Console.SetIn(m_testReader);
    }
  }
}
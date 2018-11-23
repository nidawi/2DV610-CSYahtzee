﻿using System;
using System.Collections.Generic;
using System.Text;

using CSYahtzee.model;

using Xunit;
using Moq;

namespace CSYahtzee.Tests.model
{
  public class CategoryScoreUnitTests
  {
    private CategoryScore sut;

    [Theory]
    [InlineData(ScoreCategory.Aces)]
    [InlineData(ScoreCategory.Twos)]
    [InlineData(ScoreCategory.Threes)]
    [InlineData(ScoreCategory.Fours)]
    [InlineData(ScoreCategory.Fives)]
    [InlineData(ScoreCategory.Sixes)]
    [InlineData(ScoreCategory.ThreeOfAKind)]
    [InlineData(ScoreCategory.FourOfAKind)]
    [InlineData(ScoreCategory.FullHouse)]
    [InlineData(ScoreCategory.SmallStraight)]
    [InlineData(ScoreCategory.LargeStraight)]
    [InlineData(ScoreCategory.Yahtzee)]
    [InlineData(ScoreCategory.Chance)]
    public void ConstructorShouldNotThrowWhenGivenValidCategory(ScoreCategory a_scoreCategory)
    {
      sut = new CategoryScore(a_scoreCategory);
      Assert.True(sut != null);
    }

    [Theory]
    [InlineData(ScoreCategory.Aces)]
    [InlineData(ScoreCategory.Twos)]
    [InlineData(ScoreCategory.Threes)]
    [InlineData(ScoreCategory.Fours)]
    [InlineData(ScoreCategory.Fives)]
    [InlineData(ScoreCategory.Sixes)]
    [InlineData(ScoreCategory.ThreeOfAKind)]
    [InlineData(ScoreCategory.FourOfAKind)]
    [InlineData(ScoreCategory.FullHouse)]
    [InlineData(ScoreCategory.SmallStraight)]
    [InlineData(ScoreCategory.LargeStraight)]
    [InlineData(ScoreCategory.Yahtzee)]
    [InlineData(ScoreCategory.Chance)]
    public void CategoryPropertyShouldReturnSetCategory(ScoreCategory a_scoreCategory)
    {
      sut = new CategoryScore(a_scoreCategory);
      ScoreCategory expected = a_scoreCategory;
      ScoreCategory actual = sut.Category;
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void SetShouldNotThrowWhenCalledWithValidArguments()
    {
      sut = new CategoryScore(ScoreCategory.Aces);
      List<int> faceValues = new List<int>() { 1, 1, 1, 1, 1 };
      sut.Set(25, faceValues);
    }

    [Fact]
    public void SetShouldThrowWhenCalledWithInvalidNumberOfDiceFaceValues()
    {
      sut = new CategoryScore(ScoreCategory.Aces);
      Assert.Throws<ArgumentOutOfRangeException>(delegate ()
      {
        sut.Set(25, new List<int>() { 1, 1, 1 }); // 5 or 6 dice is valid.
      });
    }

    [Fact]
    public void SetShouldThrowWhenCalledWithAnyInvalidDiceFaceValues()
    {
      sut = new CategoryScore(ScoreCategory.Aces);
      Assert.Throws<InvalidDieException>(delegate ()
      {
        sut.Set(25, new List<int>() { -1, -1, 9, 8, 1 }); // [1..6] is valid
      });
    }

    [Fact]
    public void SetShouldThrowWhenCalledWithNegativeScoreValue()
    {
      sut = new CategoryScore(ScoreCategory.Aces);
      Assert.Throws<ArgumentOutOfRangeException>(delegate ()
      {
        sut.Set(-2, new List<int>() { 1, 1, 1, 1, 1 });
      });
    }
  }
}

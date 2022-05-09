using NUnit.Framework;
using Solutions;

namespace Tests;

[TestFixture]
public class Solution17Tests
{
    [SetUp]
    public void SetUp()
    {
        solution = new Solution17();
    }

    private Solution17 solution;

    [TestCase("23", new[]{"ad","ae","af","bd","be","bf","cd","ce","cf"})]
    public void Tests(string digits, string[] expected)
    {
        var actual = solution.LetterCombinations(digits);
        Assert.AreEqual(expected, actual);
    }
}
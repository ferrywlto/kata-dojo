using System.Runtime.InteropServices;
using Xunit;
using Xunit.Abstractions;

namespace dojo.leetcode;
public class Q9_PalindromeNumberTests 
{
    private readonly ITestOutputHelper _outputHelper;
    public Q9_PalindromeNumberTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void ShouldReturnFalseForNegativeNumber()
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome(-121);
        Assert.False(result);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(9)]
    public void ShouldReturnTrueForSingleDigit(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome(input);
        Assert.True(result);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(99)]
    public void ShouldReturnTrueForDoubleDigits_DivisibleBy11(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome(input);
        Assert.True(result);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(21)]
    [InlineData(89)]
    public void ShouldReturnFalseForDoubleDigits_NotDivisibleBy11(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome(input);
        Assert.False(result);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(300)]
    [InlineData(9990)]
    public void ShouldReturnFalseIfDivisibleBy10(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome(input);
        Assert.False(result);
    }

    [Fact]
    public void Test() {
        var input = new[]{1,10,121,123,131};
        var sut = new Q9_PalindromeNumber();
        foreach (var item in input)
        {
            var result = sut.IsPalindrome(item);
            _outputHelper.WriteLine($"Testing {item}: {Math.Log10(item)}, result: {result}");
        }
    }

}

public class Q9_PalindromeNumber
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        else if (x == 0) return true;
        else if (x % 10 == 0) return false;

        var digitCount = DigitCount(x);
        switch (digitCount) {
            case 1: return true;
            case 2: return x % 11 == 0; 
        }
        
        return false;
    }

    public int DigitCount(int digit) {
        return (int)Math.Ceiling(Math.Log10(digit));
    }

    public int DigitValue(int input, int digit) {
        var divisor = (int)Math.Pow(10, digit);
        var reminder = input % divisor;
        var x = input - reminder;
        var y = x / divisor;
        return y;
    }
    // 1. know how many digits
    // 2. get truncate(digits/2) as times
    // 3. left = digits, right = 1
    // 4. for times, get left digit value and right digit value
    // 5. if left != right, return false
    // 6. left - 1, right + 1, repeat
}
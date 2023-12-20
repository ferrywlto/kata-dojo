using System.Runtime.InteropServices;
using Newtonsoft.Json.Bson;
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

    [Theory]
    [InlineData(121)]
    [InlineData(323)]
    [InlineData(1331)]
    [InlineData(9889)]
    [InlineData(18881)]
    [InlineData(18981)]
    [InlineData(189981)]
    [InlineData(888888)]
    public void ShouldReturnTrueOnPalindrome(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome(input);
        Assert.True(result);
    }
    // [Fact]
    // public void Test() {
    //     var input = new[]{1,10,121,123,131};
    //     var sut = new Q9_PalindromeNumber();
    //     foreach (var item in input)
    //     {
    //         var result = sut.IsPalindrome(item);
    //         _outputHelper.WriteLine($"Testing {item}: {Math.Log10(item)}, result: {result}");
    //     }
    // }
    [Fact]
    public void TestDigitValue() {
        var sut = new Q9_PalindromeNumber();
        var numToTest = 12345;
        // Assert.Equal(5, sut.DigitValue(numToTest, 0));
        // Assert.Equal(4, sut.DigitValue(numToTest, 1));
        // Assert.Equal(3, sut.DigitValue(numToTest, 2));
        Assert.Equal(2, sut.DigitValue(numToTest, 3));
        Assert.Equal(1, sut.DigitValue(numToTest, 4));
    }

    [Fact]
    public void TestRemoveLeft() {
        var sut = new Q9_PalindromeNumber();
        var numToTest = 12345;
        Assert.Equal(12345, sut.RemoveLeft(numToTest, 5));
        Assert.Equal(12345, sut.RemoveLeft(numToTest, 4));
        Assert.Equal(2345, sut.RemoveLeft(numToTest, 3));
        Assert.Equal(345, sut.RemoveLeft(numToTest, 2));
        Assert.Equal(45, sut.RemoveLeft(numToTest, 1));
        Assert.Equal(5, sut.RemoveLeft(numToTest, 0));
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
        
        var times = Math.Truncate((decimal)(digitCount / 2));
        var left = digitCount-1;
        var right = 0;
        Console.WriteLine($"input:{x}, count:{digitCount}, times: {times}, left: {left}, right: {right}");
        for(var i = 0; i < times; i++) {
            var leftDigit = DigitValue(x, left);
            var rightDigit = DigitValue(x, right);
            Console.WriteLine($"left: {left}, right: {right}, left value: {leftDigit}, right value: {rightDigit}");   
            if (leftDigit != rightDigit) return false;
            left--;
            right++;
        }
        return true;
    }

    public int DigitCount(int digit) {
        return (int)Math.Ceiling(Math.Log10(digit));
    }

    public int DigitValue(int input, int position, int digitCount) {
        // This only remove values on the right
        var divisor = (int)Math.Pow(10, position);
        var reminder = (input % divisor);
        var x = (input - (input % divisor));
        var y = (input - (input % divisor)) / divisor;
        Console.WriteLine($"input: {input}, digit: {position}, divisor: {divisor}, reminder: {reminder}, x: {x}, y: {y}");
        // return (input - (input % divisor)) / divisor;
        // Need to remove values on the left
        // e.g. 12345, dight = 2, digitCount = 5, digitToRemoveFromRight = 2, digitToRemoveFromLeft = 5-2-1 = 2;
        // e.g. 123456, digit = 2, digitCount = 6, digitToRemoveFromRight = 2, digitToRemoveFromLeft = 6-2-1 = 3;
        // e.g. 123456, digit = 3, digitCount = 6, digitToRemoveFromRight = 3, digitToRemoveFromLeft = 6-3-1 = 2;  
        
        // remove left
        
        return y;
    }
    public int RemoveLeft(int input, int position) {
        var divisor = (int)Math.Pow(10, position+1);
        return (input % divisor);
    }
    public int RemoveRight(int input, int position) {
        var divisor = (int)Math.Pow(10, position);
        return input - (input % divisor);
    }
    // Call this after remove both left and right, the result should always an integer
    public int DigitValue(int input, int position) {
        var divisor = (int)Math.Pow(10, position);
        return input / divisor;
    }
    // 34000
    // 34000 % 1000 = 0

    // ALGORITHM
    // 1. know how many digits
    // 2. get truncate(digits/2) as times
    // 3. left = digits, right = 1
    // 4. for times, get left digit value and right digit value
    // 5. if left != right, return false
    // 6. left - 1, right + 1, repeat
}
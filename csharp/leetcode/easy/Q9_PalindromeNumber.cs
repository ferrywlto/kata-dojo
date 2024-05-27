public class Q9_PalindromeNumberTests
{
    [Fact]
    public void ShouldReturnFalseForNegativeNumber()
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome_CorrectApproach(-121);
        Assert.False(result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(9)]
    public void ShouldReturnTrueForSingleDigit(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome_CorrectApproach(input);
        Assert.True(result);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(99)]
    public void ShouldReturnTrueForDoubleDigits_DivisibleBy11(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome_CorrectApproach(input);
        Assert.True(result);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(21)]
    [InlineData(89)]
    public void ShouldReturnFalseForDoubleDigits_NotDivisibleBy11(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome_CorrectApproach(input);
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
        var result = sut.IsPalindrome_CorrectApproach(input);
        Assert.False(result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(9)]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(121)]
    [InlineData(323)]
    [InlineData(888)]
    [InlineData(1331)]
    [InlineData(9889)]
    [InlineData(9999)]
    [InlineData(18881)]
    [InlineData(18981)]
    [InlineData(88888)]
    [InlineData(189981)]
    [InlineData(888888)]
    public void ShouldReturnTrueOnPalindrome(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome_CorrectApproach(input);
        Assert.True(result);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(21)]
    [InlineData(122)]
    [InlineData(221)]
    [InlineData(1231)]
    [InlineData(1321)]
    [InlineData(1223)]
    [InlineData(3221)]
    [InlineData(12223)]
    [InlineData(32221)]
    [InlineData(2147483647)]
    public void ShouldReturnFalseOnNonPalindrome(int input)
    {
        var sut = new Q9_PalindromeNumber();
        var result = sut.IsPalindrome_CorrectApproach(input);
        Assert.False(result);
    }

    [Fact]
    public void TestDigitValue()
    {
        var sut = new Q9_PalindromeNumber();
        var numToTest = 12345;
        Assert.Equal(5, sut.DigitValue(numToTest, 0));
        Assert.Equal(4, sut.DigitValue(numToTest, 1));
        Assert.Equal(3, sut.DigitValue(numToTest, 2));
        Assert.Equal(2, sut.DigitValue(numToTest, 3));
        Assert.Equal(1, sut.DigitValue(numToTest, 4));
    }

    [Fact]
    public void TestRemoveLeft()
    {
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

class Q9_PalindromeNumber
{
    public bool IsPalindrome_ToStringApproach(int x)
    {
        var str = x.ToString();
        if (str.StartsWith('-')) return false;
        if (str.Length == 1) return true;
        var times = Math.Floor((float)(str.Length / 2));

        for (var i = 0; i < times; i++)
        {
            if (str[i] != str[^(i + 1)]) return false;
        }
        return true;
    }

    // ALGORITHM
    // 1. know how many digits
    // 2. get truncate(digits/2) as times
    // 3. left = digits, right = 1
    // 4. for times, get left digit value and right digit value
    // 5. if left != right, return false
    // 6. left - 1, right + 1, repeat

    // return (input - (input % divisor)) / divisor;
    // Need to remove values on the left
    // e.g. 12345, dight = 2, digitCount = 5, digitToRemoveFromRight = 2, digitToRemoveFromLeft = 5-2-1 = 2;
    // e.g. 123456, digit = 2, digitCount = 6, digitToRemoveFromRight = 2, digitToRemoveFromLeft = 6-2-1 = 3;
    // e.g. 123456, digit = 3, digitCount = 6, digitToRemoveFromRight = 3, digitToRemoveFromLeft = 6-3-1 = 2;  
    public bool IsPalindrome_IntergerApproach(int x)
    {
        if (x < 0) return false;
        else if (x % 10 == 0) return false;
        else if (x == 0) return true;

        var digitCount = DigitCount(x);
        switch (digitCount)
        {
            case 1: return true;
            case 2: return x % 11 == 0;
        }

        var times = Math.Truncate((decimal)(digitCount / 2));
        var left = digitCount - 1;
        var right = 0;
        for (var i = 0; i < times; i++)
        {
            var leftDigit = DigitValue(x, left);
            var rightDigit = DigitValue(x, right);
            if (leftDigit != rightDigit) return false;
            left--;
            right++;
        }
        return true;
    }

    public int DigitCount(int digit)
    {
        return (int)Math.Ceiling(Math.Log10(digit));
    }

    public int RemoveLeft(int input, int position)
    {
        var divisor = (int)Math.Pow(10, position + 1);
        return (input % divisor);
    }

    // remove left
    // Call this after remove both left and right, the result should always an integer
    public int DigitValue(int input, int position)
    {
        var removedLeft = RemoveLeft(input, position);
        var divisor = (int)Math.Pow(10, position);
        return (int)Math.Truncate((decimal)(removedLeft / divisor));
    }

    // The correct appraoch is to constract a reverse number and compare with input
    // It has not much to do with the performance as most solutions are just 3-lines string approach
    // Not sure how could the performance improve further
    // Speed: 38ms (55.1%) | Memory: 31.5MB (30.8%)  
    public bool IsPalindrome_CorrectApproach(int x)
    {
        if (x < 0) return false;
        if (x % 10 == 0 && x != 0) return false;
        if (x < 10) return true;

        var input = x;
        var reverse = 0;
        while (input > 0)
        {
            reverse = reverse * 10 + input % 10;
            input /= 10;
        }
        return x == reverse;
    }
}
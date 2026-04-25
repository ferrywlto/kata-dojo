using System.Text;

public class Q2375_ConstructSmallestNumberFromDIString
{
    // TC: O(n), n scale with length of pattern
    // SC: O(n), to hold the result
    public string SmallestNumber(string pattern)
    {
        var paddedPattern = "I" + pattern;
        var sbResult = new StringBuilder();
        var smallestLeft = 1;

        for (var i = 0; i < paddedPattern.Length; i++)
        {
            if (paddedPattern[i] == 'I')
            {
                var followingDecreaseCount = 0;
                for (var j = i + 1; j < paddedPattern.Length; j++)
                {
                    if (paddedPattern[j] == 'I') break;
                    followingDecreaseCount++;
                }
                var digit = smallestLeft + followingDecreaseCount;
                sbResult.Append(digit);
                smallestLeft = digit + 1;
            }
            else
            {
                var lastNumber = sbResult[^1] - 1;
                sbResult.Append((char)lastNumber);
            }
        }
        return sbResult.ToString();
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"IIIDIDDD", "123549876"},
        {"DDD", "4321"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SmallestNumber(input);
        Assert.Equal(expected, actual);
    }
}

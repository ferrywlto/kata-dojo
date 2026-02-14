class Q1796_SecondLargestDigitInString
{
    // TC: O(n), where n is length of s
    // SC: O(1), space used is fixed
    public int SecondHighest(string s)
    {
        var secondLargest = -1;
        var largest = -1;
        foreach (var c in s)
        {
            if (c >= '0' && c <= '9')
            {
                var digit = c - '0';
                if (digit > largest)
                {
                    secondLargest = largest;
                    largest = digit;
                }
                else if (digit == largest) continue;
                else if (digit > secondLargest)
                {
                    secondLargest = digit;
                }
            }
        }
        return secondLargest;
    }
}
class Q1796_SecondLargestDigitInStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["dfa12321afd", 2],
        ["abc1111", -1],
        ["sjhtz8344", 4],
    ];
}
public class Q1796_SecondLargestDigitInStringTests
{
    [Theory]
    [ClassData(typeof(Q1796_SecondLargestDigitInStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1796_SecondLargestDigitInString();
        var actual = sut.SecondHighest(input);
        Assert.Equal(expected, actual);
    }
}

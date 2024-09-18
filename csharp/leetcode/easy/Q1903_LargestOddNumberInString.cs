class Q1903_LargestOddNumberInString
{
    // TC: O(n), where n is the length of num worst case (no odd number found)
    // SC: O(1), space used does not scale with num 
    public string LargestOddNumber(string num)
    {
        for (var i = num.Length - 1; i >= 0; i--)
        {
            if (num[i] % 2 == 1)
            {
                return num[..(i + 1)];
            }
        }
        return string.Empty;
    }
}
class Q1903_LargestOddNumberInStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["52", "5"],
        ["4206", ""],
        ["35427", "35427"],
    ];
}
public class Q1903_LargestOddNumberInStringTests
{
    [Theory]
    [ClassData(typeof(Q1903_LargestOddNumberInStringTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1903_LargestOddNumberInString();
        var actual = sut.LargestOddNumber(input);
        Assert.Equal(expected, actual);
    }
}

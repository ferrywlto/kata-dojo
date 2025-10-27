public class Q3726_RemoveZerosInDecimalRepresentation
{
    // TC: O(d), d is the number of digits in n
    // SC: O(1), space used is constant
    public long RemoveZeros(long n)
    {
        var resultStr = n.ToString().Replace("0", "");
        return long.Parse(resultStr);
    }
    public static TheoryData<long, long> TestData => new()
    {
        { 102030, 123 },
        { 1, 1 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void RemoveZeros_ShouldReturnExpectedResult(long input, long expected)
    {
        var result = RemoveZeros(input);
        Assert.Equal(expected, result);
    }
}

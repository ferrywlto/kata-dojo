public class Q3726_RemoveZerosInDecimalRepresentation
{
    public long RemoveZeros(long n)
    {
        return 0;
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

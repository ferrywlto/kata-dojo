public class Q4039_SumOfDecodedNumbers
{
    public int SumDecoded(long[] nums)
    {
        return 0;
    }

    public static TheoryData<long[], int> TestData => new()
    {
        { [231], 8 },
        { [2522, 2101], 1649 },
        { [2301], 73741817 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(long[] input, int expected)
    {
        var actual = SumDecoded(input);
        Assert.Equal(expected, actual);
    }
}

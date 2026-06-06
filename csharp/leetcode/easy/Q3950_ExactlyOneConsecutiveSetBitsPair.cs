public class Q3950_ExactlyOneConsecutiveSetBitsPair
{
    public bool ConsecutiveSetBits(int n)
    {
        return false;
    }

    public static TheoryData<int, bool> TestData => new() { { 6, true }, { 5, false } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = ConsecutiveSetBits(input);
        Assert.Equal(expected, actual);
    }
}

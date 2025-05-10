public class Q2125_NumLaserBeamsinBank
{
    public int NumberOfBeams(string[] bank)
    {
        return 0;
    }
    public static TheoryData<string[], int> TestData => new()
    {
        {["011001","000000","010100","001000"], 8},
        {["000","111","000"], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = NumberOfBeams(input);
        Assert.Equal(expected, actual);
    }
}
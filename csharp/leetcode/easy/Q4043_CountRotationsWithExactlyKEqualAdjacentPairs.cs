public class Q4043_CountRotationsWithExactlyKEqualAdjacentPairs
{
    public int CountRotations(string s, int k)
    {
        return 0;
    }

    public static TheoryData<string, int, int> TestData => new()
    {
        { "aab", 1, 2 },
        { "abca", 0, 1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int n, int expected)
    {
        var actual = CountRotations(input, n);
        Assert.Equal(expected, actual);
    }
}

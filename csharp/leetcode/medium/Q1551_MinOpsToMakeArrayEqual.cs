public class Q1551_MinOpsToMakeArrayEqual//(ITestOutputHelper output)
{
    // TC: O(n)
    // SC: O(1)
    public int MinOperations(int n)
    {
        var result = 0;
        // all elements should be n at last,
        // cal diff from last
        // one ops will +1/-1 thus only need to calculate the first half diff.
        var len = n / 2;
        for (var i = 0; i < len; i++)
        {
            var expected = (2 * i) + 1;
            // since expected before n/2 must smaller than n, no need to Math.Abs()
            var diff = n - expected;
            result += diff;

        }
        return result;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {3, 2},
        {6, 9}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
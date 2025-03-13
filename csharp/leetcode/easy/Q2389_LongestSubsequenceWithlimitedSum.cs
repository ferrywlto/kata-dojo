public class Q2389_LongestSubsequenceWithlimitedSum
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        return [];
    }
    public static TheoryData<int[], int[], int[]> TestData => new()
    {
        {[2,3,4,5], [1], [0]},
        {[4,5,2,1], [3,10,21], [2,3,4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var actual = AnswerQueries(input1, input2);
        Assert.Equal(expected, actual);
    }
}
public class Q2389_LongestSubsequenceWithlimitedSum
{
    // TC: O(n * m), n scale with length nums, m scale with length of queries
    // SC: O(n) if counting result, O(1) otherwise
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        var answer = new int[queries.Length];
        Array.Sort(nums);
        for (var i = 0; i < queries.Length; i++)
        {
            var count = 0;
            var sum = 0;
            for (var j = 0; j < nums.Length; j++)
            {
                sum += nums[j];
                if (sum <= queries[i]) count++;
                else
                {
                    answer[i] = count;
                    break;
                }
            }
            if (sum <= queries[i]) answer[i] = count;
        }
        return answer;
    }
    public static TheoryData<int[], int[], int[]> TestData => new()
    {
        {[2,3,4,5], [1], [0]},
        {[4,5,2,1], [3,10,21], [2,3,4]},
        {[469781,45635,628818,324948,343772,713803,452081], [816646,929491], [3,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var actual = AnswerQueries(input1, input2);
        Assert.Equal(expected, actual);
    }
}

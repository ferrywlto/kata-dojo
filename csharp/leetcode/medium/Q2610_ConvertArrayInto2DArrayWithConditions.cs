public class Q2610_ConvertArrayInto2DArrayWithConditions
{
    // TC: O(n + n*m), n scale with length of nums, m sacle with max occurance of a number
    // SC: O(n)
    public IList<IList<int>> FindMatrix(int[] nums)
    {
        var len = nums.Length;
        var buckets = new int[len + 1];
        var maxOccurance = 0;
        for (var i = 0; i < len; i++)
        {
            var n = nums[i];
            buckets[n]++;
            if (buckets[n] > maxOccurance)
            {
                maxOccurance = buckets[n];
            }
        }
        List<IList<int>> result = new(maxOccurance);
        for (var i = 0; i < maxOccurance; i++)
        {
            result.Add([]);
        }
        for (var bucketIdx = 1; bucketIdx < buckets.Length; bucketIdx++)
        {
            var occurance = buckets[bucketIdx];

            for (var k = 0; k < occurance; k++)
            {
                result[k].Add(bucketIdx);
            }
        }
        return result;
    }
    public static TheoryData<int[], List<List<int>>> TestData => new()
    {
        {
            [1,3,4,1,2,3,1],
            [[1,2,3,4],[1,3],[1]]
        },
        {
            [1,2,3,4],
            [[1,2,3,4]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<List<int>> expected)
    {
        var actual = FindMatrix(input);
        Assert.Equal(expected, actual);
    }
}
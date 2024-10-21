public class Q2200_FindAllKDistinctIndicesInArray
{
    // TC: O(n * k), n scale with length of nums, for each n it iterate k more times
    // SC: O(n), an array is used to avoid the duplicate index sorting to improve speed from O(nlogn) to O(n)
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        var result = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == key)
            {
                for (var j = i - k; j <= i + k; j++)
                {
                    if (j < 0 || j > nums.Length - 1) continue;
                    result[j] = 1;
                }
            }
        }
        var x = new List<int>();
        for (var i = 0; i < result.Length; i++)
        {
            if (result[i] == 1) x.Add(i);
        }
        return x;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,4,9,1,3,9,5}, 9, 1, new int[] {1,2,3,4,5,6}],
        [new int[] {2,2,2,2,2}, 2, 2, new int[] {0,1,2,3,4}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int key, int k, int[] expected)
    {
        var actual = FindKDistantIndices(input, key, k);
        Assert.Equal(expected, actual);
    }
}
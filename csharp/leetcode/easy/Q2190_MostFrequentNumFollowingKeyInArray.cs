public class Q2190_MostFrequentNumberFollowingKeyInArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MostFrequent(int[] nums, int key)
    {
        var dict = new Dictionary<int, int>();
        var maxNum = -1;
        var maxCount = -1;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == key)
            {
                var target = nums[i + 1];
                if (dict.TryGetValue(target, out var val))
                {
                    dict[target] = ++val;
                    if (val > maxCount)
                    {
                        maxCount = val;
                        maxNum = target;
                    }
                }
                else
                {
                    dict.Add(target, 1);
                    if (1 > maxCount)
                    {
                        maxCount = 1;
                        maxNum = target;
                    }
                }
            }
        }
        return maxNum;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{1,100,200,1,100}, 1, 100],
        [new int[]{2,2,2,2,3}, 2, 2],
        [new int[]{1,1000,2}, 1000, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int key, int expected)
    {
        var actual = MostFrequent(input, key);
        Assert.Equal(expected, actual);
    }
}

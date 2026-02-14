public class Q2176_CountEqualAndDivisiblePairsInArray
{
    // TC: O(n^2), due to nested loop
    // SC: O(1), space used does not scale with input
    public int CountPairs_Memory(int[] nums, int k)
    {
        var pairs = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (i * j % k != 0) continue;
                else if (nums[i] == nums[j]) pairs++;
            }
        }
        return pairs;
    }
    // TC: O(m^2), better for sparse numbers
    // SC: O(n), scale with unique numbers in nums
    // Sacrifice memory for a filtering before the calculation
    public int CountPairs(int[] nums, int k)
    {
        var idxDict = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (idxDict.TryGetValue(nums[i], out var list)) list.Add(i);
            else idxDict.Add(nums[i], [i]);
        }
        var pairs = 0;
        foreach (var indices in idxDict.Values)
        {
            if (indices.Count < 2) continue; // no pair
            for (var i = 0; i < indices.Count - 1; i++)
            {
                for (var j = i + 1; j < indices.Count; j++)
                {
                    if (indices[i] * indices[j] % k == 0) pairs++;
                }
            }
        }
        return pairs;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {3,1,2,2,2,1,3}, 2, 4],
        [new int[] {1,2,3,4}, 1, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = CountPairs(input, k);
        Assert.Equal(expected, actual);
    }
}

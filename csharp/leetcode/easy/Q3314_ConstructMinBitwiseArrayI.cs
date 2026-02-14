public class Q3314_ConstructMinBitwiseArrayI
{
    // TC: O(n^2), n scale with length of nums
    // SC: O(1), space used does not scale with input
    Dictionary<int, int> CalCache = new() { { 2, -1 } };
    public int[] MinBitwiseArray(IList<int> nums)
    {
        // Find largest
        var largest = 2;
        for (var i = 0; i < nums.Count; i++)
        {
            if (nums[i] > largest) largest = nums[i];
        }

        for (var i = 0; i <= largest; i++)
        {
            var key = (i | i + 1);
            if (key > 1000) continue;
            CalCache.TryAdd(key, i);
        }

        for (var i = 0; i < nums.Count; i++)
        {
            Shift(nums[i]);
            nums[i] = CalCache[nums[i]];
        }
        return nums.ToArray();
    }
    private int Shift(int input)
    {
        // even
        if (input % 2 == 0) return -1;

        var temp = input;
        var MSB = 1;
        while (temp > 0)
        {
            temp >>= 1;
            MSB <<= 1;
        }
        MSB >>= 1;
        return MSB;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[2,3,5,7], [-1,1,4,3]},
        {[11,13,31], [9,12,15]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinBitwiseArray(input);
        Assert.Equal(expected, actual);
    }
}

public class Q78_Subsets
{
    // TC: O(n * 2^n), n scale with length of nums, 2^n for all combinations times number of bits from 2^n.
    // SC: O(2^n), for storing result

    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var len = nums.Length;
        var max = 1;

        for (var i = 0; i < len; i++) max *= 2;

        for (var j = 0; j < max; j++)
        {
            var bitIdx = len - 1;
            var tmp = j;
            var list = new List<int>();
            while (bitIdx >= 0)
            {
                if ((tmp & 1) == 1)
                {
                    list.Insert(0, nums[bitIdx]);
                }
                tmp >>= 1;
                bitIdx--;
            }
            result.Add(list);
        }

        return result;
    }
    public static TheoryData<int[], IList<IList<int>>> TestData => new()
    {
        {[1,2,3], [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]},
        {[0], [[],[0]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, IList<IList<int>> expected)
    {
        var actual = Subsets(input);
        Assert.Equal(expected, actual);
    }
}

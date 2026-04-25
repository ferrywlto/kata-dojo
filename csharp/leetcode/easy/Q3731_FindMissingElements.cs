public class Q3731_FindMissingElements
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), counts array size is fixed
    public IList<int> FindMissingElements(int[] nums)
    {
        var min = 100;
        var max = 1;
        var counts = new int[101];
        foreach (var num in nums)
        {
            counts[num]++;
            if (num < min) min = num;
            if (num > max) max = num;
        }
        var result = new List<int>();
        for (var i = min; i <= max; i++)
        {
            if (counts[i] == 0)
            {
                result.Add(i);
            }
        }
        return result;
    }
    public static TheoryData<int[], IList<int>> TestData => new()
    {
        {[1,4,2,5], [3]},
        {[7,8,6,9], []},
        {[5,1], [2,3,4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, IList<int> expected)
    {
        var result = FindMissingElements(input);
        Assert.Equal(expected, result);
    }
}

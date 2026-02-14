public class Q3046_SplitTheArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public bool IsPossibleToSplit(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        var singleCount = 0;
        foreach (var n in nums)
        {
            if (dict.TryGetValue(n, out var val))
            {
                if (val == 2) return false;
                else
                {
                    dict[n] = ++val;
                    singleCount--;
                }
            }
            else
            {
                dict.Add(n, 1);
                singleCount++;
            }
        }

        return singleCount % 2 == 0;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[2,10,2,7,8,9,7,6,6,9], true},
        {[1,1,2,2,3,4], true},
        {[1,1,1,1], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = IsPossibleToSplit(input);
        Assert.Equal(expected, actual);
    }
}

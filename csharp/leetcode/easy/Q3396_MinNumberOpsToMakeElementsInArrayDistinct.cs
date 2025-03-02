public class Q3396_MinNumberOpsToMakeElementsInArrayDistinct
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MinimumOperations(int[] nums)
    {
        var set = new HashSet<int>();
        var dup = new Dictionary<int, int>();

        var len = nums.Length;

        for(var i=0; i<len; i++)
        {
            if(!set.Add(nums[i]))
            {
                if(dup.TryGetValue(nums[i], out var val)) dup[nums[i]] = ++val;
                else dup.Add(nums[i], 1);
            }
        }
        var lastDupIdx = -1;
        for(var j=0; j<len; j++)
        {
            if(dup.TryGetValue(nums[j], out var val))
            {
                if(val > 1) dup[nums[j]] = --val;
                else 
                {
                    if(dup.Count == 1)
                    {
                        lastDupIdx = j;
                        break;
                    }
                    dup.Remove(nums[j]);
                }
            }
        }
        return lastDupIdx == -1 ? 0 : lastDupIdx / 3 + 1;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3, 4,2,3, 3,5,7], 2}, // idx 6
        {[2,1,2, 2,1,2, 1,2,3, 4], 2}, // idx 5, /3 = 1 %3/ 2
        {[2,7,15,1,15], 1}, // idx 4
        {[4,5,6, 4,4], 2}, // idx 4
        {[4,5,6, 4,3], 1}, // idx 3
        {[6,7,8,9], 0}, // idx -1
        {[5,10,10], 1}, // idx 2
        {[2,2,2,2,2], 2}, // idx 4
        {[2,2,2,2,2,2], 2}, // idx 5
        {[2,2,2,2,2,1], 2}, // idx 4, /2
        {[2,2,2,2,2,2,1], 2}, // idx 5, /3 = 1 %3/ 2
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}
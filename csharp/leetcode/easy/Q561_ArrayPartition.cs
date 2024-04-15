public class Q561_ArrayPartition
{
    // TC: O(n log n)
    // SC: O(1)
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);
        var max = 0;
        for(var i=0; i<nums.Length; i+=2)
        {
            // no need Math.Min(nums[i], nums[i + 1]) as nums[i] must smaller than nums[i+1] after sorted
            max += nums[i];
        }
        return max;
    }
}

public class Q561_ArrayPartitionTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1, 4, 3, 2}, 4],
        [new int[] {6, 2, 6, 5, 1, 2}, 9],
    ];
}

public class Q561_ArrayPartitionTests
{
    [Theory]
    [ClassData(typeof(Q561_ArrayPartitionTestData))]
    public void OfficialTestCases(int[] nums, int expected)
    {
        var sut = new Q561_ArrayPartition();
        var actual = sut.ArrayPairSum(nums);
        Assert.Equal(expected, actual);
    }
}
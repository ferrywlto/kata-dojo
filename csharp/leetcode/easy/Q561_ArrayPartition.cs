namespace dojo.leetcode;

public class Q561_ArrayPartition
{
    // example 1: nums.length = 4, n = 2, get 2 pairs -> 4C2 = 6 possible pairs
    // example 2: nums.length = 6, n = 3, get 3 pairs -> 6C2 = 15 possible pairs
    public int ArrayPairSum(int[] nums)
    {
        return 0;
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
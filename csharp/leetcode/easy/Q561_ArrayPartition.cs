namespace dojo.leetcode;

public class Q561_ArrayPartition
{
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

namespace dojo.leetcode;

public class Q303_RangeSumQuery(int[] nums)
{
    protected readonly int[] Nums = nums;

    public int SumRange(int left, int right)
    {
        return 0;
    }
}

public class Q303_RangeSumQueryTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{-2, 0, 3, -5, 2, -1}, 0, 2, 1],
        [new int[]{-2, 0, 3, -5, 2, -1}, 2, 5, -1],
        [new int[]{-2, 0, 3, -5, 2, -1}, 0, 5, -3],
    ];
}

public class Q303_RangeSumQueryTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q303_RangeSumQueryTestData))]
    public void OfficialTestCases(int[] input, int left, int right, int expected)
    {
        var sut = new Q303_RangeSumQuery(input);
        var actual = sut.SumRange(left, right);
        Assert.Equal(expected, actual);
    }
}
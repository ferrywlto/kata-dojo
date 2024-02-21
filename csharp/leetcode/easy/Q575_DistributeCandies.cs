namespace dojo.leetcode;

public class Q575_DistributeCandies
{
    // hashset<int> -> Math.Min(hashset.length, candyType.length/2)
    // [1,2,3,4] -> 2
    // [1,2,3,4,1,2,3,4] -> 4
    // [1,2,3,3,3,4] -> 3
    public int DistributeCandies(int[] candyType)
    {
        return 0;
    }
}

public class Q575_DistributeCandiesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1, 1, 2, 2, 3, 3}, 3],
        [new int[] {1, 1, 2, 3}, 2],
        [new int[] {6, 6, 6, 6}, 1],
    ];
}

public class Q575_DistributeCandiesTests
{
    [Theory]
    [ClassData(typeof(Q575_DistributeCandiesTestData))]
    public void OfficialTestCases(int[] candyType, int expected)
    {
        var sut = new Q575_DistributeCandies();
        var actual = sut.DistributeCandies(candyType);
        Assert.Equal(expected, actual);
    }
}
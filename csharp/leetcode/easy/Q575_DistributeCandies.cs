class Q575_DistributeCandies
{
    // hashset<int> -> Math.Min(hashset.length, candyType.length/2)
    // [1,2,3,4] -> 2
    // [1,2,3,4,1,2,3,4] -> 4
    // [1,2,3,3,3,4] -> 3
    // TC: O(n)
    // SC: O(n)
    public int DistributeCandies(int[] candyType)
    {
        var hashset = candyType.ToHashSet<int>();

        return Math.Min(hashset.Count, candyType.Length / 2);
    }
}

class Q575_DistributeCandiesTestData : TestData
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

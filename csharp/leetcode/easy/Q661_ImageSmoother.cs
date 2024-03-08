namespace dojo.leetcode;

public class Q661_ImageSmoother
{
    public int[][] ImageSmoother(int[][] img)
    {
        return [];
    }
}

public class Q661_ImageSmootherTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][] { [1, 1, 1], [1, 0, 1], [1, 1, 1] },
            new int[][] { [0, 0, 0], [0, 0, 0], [0, 0, 0] }
        ],
        [
            new int[][] { [100,200,100],[200,50,200],[100,200,100] },
            new int[][] { [137,141,137],[141,138,141],[137,141,137] }
        ],
    ];
}

public class Q661_ImageSmootherTests
{
    [Theory]
    [ClassData(typeof(Q661_ImageSmootherTestData))]
    public void OfficialTestCases(int[][] input, int[][] expected)
    {
        var sut = new Q661_ImageSmoother();
        var actual = sut.ImageSmoother(input);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
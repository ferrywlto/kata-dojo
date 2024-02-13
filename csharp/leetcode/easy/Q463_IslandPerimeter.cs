namespace dojo.leetcode;

public class Q463_IslandPerimeter
{
    // TC: O(n), SC: O(1)
    public int IslandPerimeter(int[][] grid)
    {
        return 0;
    }
}

public class Q463_IslandPerimeterTestData: TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[0, 1, 0, 0], [1, 1, 1, 0], [0, 1, 0, 0], [1, 1, 0, 0]}, 16],
        [new int[][] {[1]}, 4],
        [new int[][] {[1, 0]}, 4],
    ];
}

public class Q463_IslandPerimeterTests
{
    [Theory]
    [ClassData(typeof(Q463_IslandPerimeterTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q463_IslandPerimeter();
        var actual = sut.IslandPerimeter(input);
        Assert.Equal(expected, actual);
    }
}
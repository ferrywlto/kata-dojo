namespace dojo.leetcode;

public class Q492_ConstructTheRectangle
{
    public int[] ConstructRectangle(int area)
    {
        return [];
    }
}

public class Q492_ConstructTheRectangleTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [4, new int[] { 2, 2 }],
        [37, new int[] { 37, 1 }],
        [122122, new int[] { 427, 286 }],
    ];
}

public class Q492_ConstructTheRectangleTests
{
    [Theory]
    [ClassData(typeof(Q492_ConstructTheRectangleTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q492_ConstructTheRectangle();
        var actual = sut.ConstructRectangle(input);
        Assert.Equal(expected, actual);
    }
}
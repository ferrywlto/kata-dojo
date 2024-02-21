namespace dojo.leetcode;

public class Q563_BinaryTreeTilt
{
    public int FindTilt(TreeNode root)
    {
        return 0;
    }
}

public class Q563_BinaryTreeTiltTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {1, 2, 3}, 1],
        [new int?[] {4, 2, 9, 3, 5, null, 7}, 15],
    ];   
}

public class Q563_BinaryTreeTiltTests
{
    [Theory]
    [ClassData(typeof(Q563_BinaryTreeTiltTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q563_BinaryTreeTilt();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.FindTilt(tree!);
        Assert.Equal(expected, actual);
    }
}
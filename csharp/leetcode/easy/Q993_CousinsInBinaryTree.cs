class Q997_CousinsInBinaryTree
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        return false;
    }
}

class Q997_CousinsInBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1,2,3,4}, 4, 3, false],
        [new int?[]{1,2,3,null,4,null,5}, 5, 4, true],
        [new int?[]{1,2,3,null,4}, 2, 3, false],
    ];
}

public class Q997_CousinsInBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q997_CousinsInBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int x, int y, bool expected)
    {
        var sut = new Q997_CousinsInBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsCousins(tree!, x, y);
        Assert.Equal(expected, actual);
    }
}
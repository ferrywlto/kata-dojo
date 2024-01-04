using dojo.leetcode;

public class Q104_MaxDepthBinaryTreeTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
    [
        [new int?[]{3, 9, 20, null, null, 15, 7}, 3],
        [new int?[]{1, null, 2}, 2],
        [Array.Empty<int?>(), 0],
        [new int?[]{0}, 1],
    ];
}
public class Q104_MaxDepthBinaryTreeTests 
{
    [Theory]
    [ClassData(typeof(Q104_MaxDepthBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected) 
    {
        var sut = new Q104_MaxDepthBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.MaxDepth(tree!);
        Assert.Equal(expected, actual);
    }
}

public class Q104_MaxDepthBinaryTree
{
    public int MaxDepth(TreeNode root)
    {
        return 0;
    }
} 
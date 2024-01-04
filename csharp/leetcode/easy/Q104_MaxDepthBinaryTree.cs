using dojo.leetcode;

public class Q104_MaxDepthBinaryTreeTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
    [
        [new int?[]{3, 9, 20, null, null, 15, 7}, 3],
        [new int?[]{1, null, 2}, 2],
        [Array.Empty<int?>(), 0],
        [new int?[]{0}, 1],
        [new int?[]{1,2}, 2],
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
    // TC: O(n), SC: O(n)
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + Math.Max(MaxDepth(root.left!),MaxDepth(root?.right!));
    }
 } 
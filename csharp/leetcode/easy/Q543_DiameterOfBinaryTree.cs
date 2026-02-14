class Q543_DiameterOfBinaryTree
{
    private int max = 0;
    // TC: O(n)
    // SC: O(n)
    public int DiameterOfBinaryTree(TreeNode root)
    {
        _ = GetLongerDepth(root);
        return max;
    }
    public int GetLongerDepth(TreeNode? node)
    {
        if (node == null) return 0;

        var maxLeftDepth = GetLongerDepth(node.left);
        var maxRightDepth = GetLongerDepth(node.right);

        var sum = maxLeftDepth + maxRightDepth;
        if (sum > max)
            max = sum;

        return 1 + Math.Max(maxLeftDepth, maxRightDepth); ;
    }
}

class Q543_DiameterOfBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {1,2,3,4,5}, 3],
        [new int?[] {1,2}, 1],
    ];
}

public class Q543_DiameterOfBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q543_DiameterOfBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q543_DiameterOfBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.DiameterOfBinaryTree(tree!);
        Assert.Equal(expected, actual);
    }
}

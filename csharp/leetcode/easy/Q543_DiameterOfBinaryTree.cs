namespace dojo.leetcode;

public class Q543_DiameterOfBinaryTree
{
    // recursive check Math.Max(left depth, max left depth so far)
    // recursive check Math.Max(right depth, max right depth so far)
    // return max left depth + max right depth?
    // max depth must exist only between leaves
    private int max = 0;
    // TC: O(n)
    // SC: O(n)
    public int DiameterOfBinaryTree(TreeNode root)
    {
        _ = GetLongerDepth(root);
        return max;
    }
    public int GetLongerDepth(TreeNode node)
    {
        // need to get max depth of left and max depth of right for each node
        // var newDepth = depth + 1;
        
        if (node.IsLeaf) return 1;

        var maxLeftDepth = node.left == null ? 0 : GetLongerDepth(node.left);
        var maxRightDepth = node.right == null ? 0 : GetLongerDepth(node.right);

        var sum = maxLeftDepth + maxRightDepth;
        if (sum > max)
            max = sum;

        var currentMax = 1 + Math.Max(maxLeftDepth, maxRightDepth);
        return currentMax;
    }
}

public class Q543_DiameterOfBinaryTreeTestData : TestData
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
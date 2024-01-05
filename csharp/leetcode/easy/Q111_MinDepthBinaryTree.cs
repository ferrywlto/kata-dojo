namespace dojo.leetcode;

public class Q111_MinDepthBinaryTreeTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
    [
        [new int?[]{3,9,20,null,null,15,7}, 2],
        [new int?[]{2,null,3,null,4,null,5,null,6}, 5],
        [Array.Empty<int?>(), 0],
    ];
}
public class Q111_MinDepthBinaryTreeTests 
{
    [Theory]
    [ClassData(typeof(Q111_MinDepthBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q111_MinDepthBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.MinDepth(tree!);
        Assert.Equal(expected, actual);
    }
}

public class Q111_MinDepthBinaryTree 
{
    public int MinDepth(TreeNode? root) 
    {
        if (root == null) return 0;
        else if (root.left == null && root.right == null) return 1;
        else return CountMinRecursive(root, 1);
    }
    public int CountMinRecursive(TreeNode? node, int depth)
    {
        // is leaf
        if (node?.left == null && node?.right == null) 
        {
            return depth;
        }
        else 
        {
            var leftCount = node?.left == null? int.MaxValue : CountMinRecursive(node?.left, depth + 1);
            var rightCount = node?.right == null? int.MaxValue : CountMinRecursive(node?.right, depth + 1);
            return Math.Min(leftCount, rightCount);
        }
    }   
}
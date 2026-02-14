class Q112_BinaryTreePathSumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{5,4,8,11,null,13,4,7,2,null,null,null,1}, 22, true],
        [new int?[]{1,2,3}, 5, false],
        [new int?[]{1,2}, 1, false],
        [Array.Empty<int?>(), 0, false],
    ];
}

public class Q112_BinaryTreePathSumTests
{
    [Theory]
    [ClassData(typeof(Q112_BinaryTreePathSumTestData))]
    public void OfficialTestCases(int?[] input, int targetSum, bool expected)
    {
        var sut = new Q112_BinaryTreePathSum();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        Assert.Equal(expected, sut.HasPathSum(tree!, targetSum));
    }
}

class Q112_BinaryTreePathSum
{
    // TC: O(n), SC: O(n)
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        // return SumRecursive(root, 0, targetSum); 
        return SumIterative(root, targetSum);
    }

    public bool SumRecursive(TreeNode? node, int sum, int targetSum)
    {
        if (node == null) return false;
        if (sum + node.val == targetSum && node.IsLeaf) return true;

        return SumRecursive(node.left, sum + node.val, targetSum) || SumRecursive(node.right, sum + node.val, targetSum);
    }

    // Demonostrate iterative solution in addition to recursive solution
    public bool SumIterative(TreeNode? node, int targetSum)
    {
        if (node == null) return false;

        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((node, 0));

        while (queue.Count > 0)
        {
            var (current, levelSum) = queue.Dequeue();
            if (current.IsLeaf)
            {
                if (levelSum + current.val == targetSum)
                    return true;
            }
            if (current.left != null) queue.Enqueue((current.left, levelSum + current.val));
            if (current.right != null) queue.Enqueue((current.right, levelSum + current.val));
        }
        return false;
    }
}

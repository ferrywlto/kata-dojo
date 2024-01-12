namespace dojo.leetcode;

public class Q111_MinDepthBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
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
        else if (root.IsLeaf) return 1;
        else return CountMinIterative(root);
        // else return CountMinRecursive(root, 1);
    }
    public int CountMinRecursive(TreeNode node, int depth)
    {
        // is leaf
        if (node.IsLeaf)
        {
            return depth;
        }
        else
        {
            var leftCount = node?.left == null ? int.MaxValue : CountMinRecursive(node.left, depth + 1);
            var rightCount = node?.right == null ? int.MaxValue : CountMinRecursive(node.right, depth + 1);
            return Math.Min(leftCount, rightCount);
        }
    }

    // TC: O(n), SC: O(n)
    public int CountMinIterative(TreeNode root)
    {
        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 1));
        var min = int.MaxValue;

        while (queue.Count > 0)
        {
            var (current, depth) = queue.Dequeue();

            if (current.IsLeaf)
            {
                if (depth < min) min = depth;
            }
            // Early termination as we are finding min depth, any further drill down of a tree with depth >= min is not necessary
            else if (depth >= min)
            {
                continue;
            }
            else
            {
                if (current.left != null) queue.Enqueue((current.left, depth + 1));
                if (current.right != null) queue.Enqueue((current.right, depth + 1));
            }
        }
        return min;
    }
}
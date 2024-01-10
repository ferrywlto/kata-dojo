namespace dojo.leetcode;

public class Q101_SymmetricTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1, 2, 2, 3, 4, 4, 3}, true],
        [new int?[]{1, 2, 2, null, 3, null, 3}, false],
    ];
}

public class Q101_SymmetricTreeTests(ITestOutputHelper output) : TreeNodeTests(output)
{
    [Theory]
    [ClassData(typeof(Q101_SymmetricTreeTestData))]
    public void OfficialTestCases(int?[] input, bool expected)
    {
        var sut = new Q101_SymmetricTree();
        var node = TreeNode.FromLevelOrderingIntArray(input);
        // var actual = sut.IsSymmetric_Recursion(node!);
        var actual = sut.IsSymmetric_Loop(node!);
        Assert.Equal(expected, actual);
    }
}

public class Q101_SymmetricTree
{
    // the idea is, given two trees, A.left should equals to B.right and vice versa.
    // Linear complexity using recursion. TC: O(nodes_of_tree), SC: O(height_of_tree)
    public bool IsSymmetric_Recursion(TreeNode root)
    {
        if (root == null || (root.left == null && root.right == null))
            return true;

        return IsSymmetric_Recursion(root.left, root.right);
    }

    public bool IsSymmetric_Recursion(TreeNode? leftTree, TreeNode? rightTree)
    {
        if (leftTree == null && rightTree == null) return true;
        else
        {
            return leftTree?.val == rightTree?.val
                && IsSymmetric_Recursion(leftTree?.left, rightTree?.right)
                && IsSymmetric_Recursion(leftTree?.right, rightTree?.left);
        }
    }

    // Demonstration purpose of not using recursion.
    public bool IsSymmetric_Loop(TreeNode root)
    {
        if (root == null || (root.left == null && root.right == null))
            return true;

        var leftQueue = new Queue<TreeNode?>();
        var rightQueue = new Queue<TreeNode?>();

        leftQueue.Enqueue(root.left);
        rightQueue.Enqueue(root.right);

        while (leftQueue.Count > 0 && rightQueue.Count > 0)
        {
            var leftCurrent = leftQueue.Dequeue();
            var rightCurrent = rightQueue.Dequeue();

            if (leftCurrent == null && rightCurrent == null) continue;
            else if (leftCurrent?.val != rightCurrent?.val) return false;

            leftQueue.Enqueue(leftCurrent?.left);
            rightQueue.Enqueue(rightCurrent?.right);

            leftQueue.Enqueue(leftCurrent?.right);
            rightQueue.Enqueue(rightCurrent?.left);
        }
        return true;
    }
}
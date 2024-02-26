namespace dojo.leetcode;

public class Q563_BinaryTreeTilt
{
    public int FindTilt(TreeNode? root)
    {
        if (root == null) return 0;

        var leftSum = SumOfTree(root.left);
        var rightSum = SumOfTree(root.right);
        var diff = Math.Abs(leftSum - rightSum);
        // Console.WriteLine($"node: {root.val}, diff: {diff}, leftSum: {leftSum}, rightSum: {rightSum}");
        return diff + FindTilt(root.left) + FindTilt(root.right);
    }

    public int SumOfTree(TreeNode? tree)
    {
        return tree == null ? 0 : tree.val + SumOfTree(tree.left) + SumOfTree(tree.right);
    }
}

public class Q563_BinaryTreeTiltTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {1, 2, 3}, 1],
        [new int?[] {4, 2, 9, 3, 5, null, 7}, 15],
        [new int?[] {21, 7, 14, 1, 1, 2, 2, 3, 3}, 9],
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
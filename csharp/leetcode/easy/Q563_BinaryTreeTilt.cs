class Q563_BinaryTreeTilt
{
    public int FindTilt(TreeNode? root)
    {
        return FindSumAndTilt(root).tilt;
    }

    public (int tilt, int sum) FindSumAndTilt(TreeNode? node)
    {
        if (node == null) return (0, 0);

        var (leftTilt, leftSum) = FindSumAndTilt(node.left);
        var (rightTilt, rightSum) = FindSumAndTilt(node.right);
        var diff = Math.Abs(leftSum - rightSum) + leftTilt + rightTilt;
        return (diff, node.val + leftSum + rightSum);
    }
}

class Q563_BinaryTreeTiltTestData : TestData
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
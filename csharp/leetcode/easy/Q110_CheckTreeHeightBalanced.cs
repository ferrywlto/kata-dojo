public class Q110_CheckTreeHeightBalanced
{   
    public bool IsBalanced(TreeNode? root)
    {
        return CheckHeight(root) != -1;
    }

    private int CheckHeight(TreeNode? node)
    {
        if (node == null) return 0;

        int leftHeight = CheckHeight(node.left);
        if (leftHeight == -1) return -1;

        int rightHeight = CheckHeight(node.right);
        if (rightHeight == -1) return -1;

        int heightDiff = Math.Abs(leftHeight - rightHeight);
        if (heightDiff > 1)
        {
            return -1;
        }
        else
        {
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}

public class Q110_CheckTreeHeightBalancedTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {3,9,20,null,null,15,7}, true],
        [new int?[] {1,2,2,3,3,null,null,4,4}, false],
        [Array.Empty<int?>(), true],
        [new int?[]{1,null,2,null,3}, false],
        [new int?[]{1,2,2,3,null,null,3,4,null,null,4}, false],
    ];
}

public class Q110_CheckTreeHeightBalancedTests
{
    [Theory]
    [ClassData(typeof(Q110_CheckTreeHeightBalancedTestData))]
    public void OfficialTestCases(int?[] input, bool expected)
    {
        var sut = new Q110_CheckTreeHeightBalanced();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsBalanced(tree!);
        Assert.Equal(expected, actual);
    }
}
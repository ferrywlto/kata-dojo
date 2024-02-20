namespace dojo.leetcode;

public class Q530_MinimumAbsoluteDifferenceInBST
{
    public int GetMinimumDifference(TreeNode root)
    {
        return 0;
    }
}

public class Q530_MinimumAbsoluteDifferenceInBSTTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new TreeNode(1, null, new TreeNode(3, new TreeNode(2), null)), 1],
        [new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(6)), 1]
    ];
}

public class Q530_MinimumAbsoluteDifferenceInBSTTests
{
    [Theory]
    [ClassData(typeof(Q530_MinimumAbsoluteDifferenceInBSTTestData))]
    public void OfficialTestCases(TreeNode root, int expected)
    {
        var sut = new Q530_MinimumAbsoluteDifferenceInBST();
        var actual = sut.GetMinimumDifference(root);
        Assert.Equal(expected, actual);
    }
}
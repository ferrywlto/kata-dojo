
namespace dojo.leetcode;

public class Q501_FindModeInBST
{
    public int[] FindMode(TreeNode root)
    {
        return [];
    }
}

public class Q501_FindModeInBSTTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new TreeNode(1, null, new TreeNode(2, new TreeNode(2), null)), new int[] {2}],
        [new TreeNode(1, null, new TreeNode(2, new TreeNode(2), new TreeNode(3))), new int[] {2}],
        [new TreeNode(1, null, new TreeNode(2, new TreeNode(2), new TreeNode(3, new TreeNode(3), null))), new int[] {2, 3}],
    ];
}

public class Q501_FindModeInBSTTests
{
    [Theory]
    [ClassData(typeof(Q501_FindModeInBSTTestData))]
    public void OfficialTestCases(TreeNode root, int[] expected)
    {
        var sut = new Q501_FindModeInBST();
        var actual = sut.FindMode(root);
        Array.Sort(expected);
        Array.Sort(actual);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}

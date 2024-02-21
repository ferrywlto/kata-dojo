namespace dojo.leetcode;

public class Q572_SubtreeOfAnotherTree
{
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        return false;
    }
}

public class Q572_SubtreeOfAnotherTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {3, 4, 5, 1, 2}, new int?[] {4, 1, 2}, true],
        [new int?[] {3, 4, 5, 1, 2, null, null, null, null, 0}, new int?[] {4, 1, 2}, false],
    ];
}

public class Q572_SubtreeOfAnotherTreeTests
{
    [Theory]
    [ClassData(typeof(Q572_SubtreeOfAnotherTreeTestData))]
    public void OfficialTestCases(int?[] root, int?[] subRoot, bool expected)
    {
        var sut = new Q572_SubtreeOfAnotherTree();
        var rootTree = TreeNode.FromLevelOrderingIntArray(root);
        var subRootTree = TreeNode.FromLevelOrderingIntArray(subRoot);
        var actual = sut.IsSubtree(rootTree, subRootTree);
        Assert.Equal(expected, actual);
    }
}
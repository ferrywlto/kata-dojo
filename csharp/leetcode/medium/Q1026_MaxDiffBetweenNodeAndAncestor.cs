public class Q1026_MaxDiffBetweenNodeAndAncestor(ITestOutputHelper output) : TreeNodeTest(output)
{
    public int MaxAncestorDiff(TreeNode root)
    {
        return 0;
    }
    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([8,3,10,1,6,null,14,null,null,4,7,13])!, 7},
        {TreeNode.FromLevelOrderingIntArray([1,null,2,null,0,3])!, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode node, int expected)
    {
        var actual = MaxAncestorDiff(node);
        Assert.Equal(expected, actual);
    }
}

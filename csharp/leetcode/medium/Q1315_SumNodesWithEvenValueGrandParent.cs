
public class Q1315_SumNodesWithEvenValueGrandParent(ITestOutputHelper output) : TreeNodeTest(output)
{
    public int SumEvenGrandparent(TreeNode root)
    {
        return 0;
    }
    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([6,7,8,2,7,1,3,9,null,1,4,null,null,null,5])!, 18},
        {TreeNode.FromLevelOrderingIntArray([1])!, 0}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, int expected)
    {
        var actual = SumEvenGrandparent(input);
        Assert.Equal(expected, actual);
    }
}
public class Q1382_BalanceBinarySearchTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    public TreeNode BalanceBST(TreeNode root) {
        return new();    
    }
    public static TheoryData<TreeNode, TreeNode> TestData => new ()
    {
        {
            TreeNode.FromLevelOrderingIntArray([1,null,2,null,3,null,4,null,null])!,
            TreeNode.FromLevelOrderingIntArray([2,1,3,null,null,null,4])!
        },
        {
            TreeNode.FromLevelOrderingIntArray([2,1,3])!,
            TreeNode.FromLevelOrderingIntArray([2,1,3])!
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, TreeNode expected)
    {
        var actual = BalanceBST(input);
        AssertTreeNodeEqual(expected, actual);
    }
}

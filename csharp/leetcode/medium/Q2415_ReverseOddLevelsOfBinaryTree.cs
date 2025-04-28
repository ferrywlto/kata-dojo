
public class Q2415_ReverseOddLevelOfBinaryTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    public TreeNode ReverseOddLevels(TreeNode root) {
     return new TreeNode();   
    }   
    public static TheoryData<TreeNode, TreeNode> TestData => new () 
    {
        {TreeNode.FromLevelOrderingIntArray([2,3,5,8,13,21,34])!, TreeNode.FromLevelOrderingIntArray([2,5,3,8,13,21,34])!},
        {TreeNode.FromLevelOrderingIntArray([7,13,11])!, TreeNode.FromLevelOrderingIntArray([7,11,13])!},
        {TreeNode.FromLevelOrderingIntArray([0,1,2,0,0,0,0,1,1,1,1,2,2,2,2])!, TreeNode.FromLevelOrderingIntArray([0,2,1,0,0,0,0,2,2,2,2,1,1,1,1])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, TreeNode expected)
    {
        var actual = ReverseOddLevels(input);
        AssertTreeNodeEqual(actual, expected);
    }
}

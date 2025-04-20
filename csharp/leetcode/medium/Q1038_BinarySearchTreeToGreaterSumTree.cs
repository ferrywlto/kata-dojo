
public class Q1038_BinarySearchTreeToGreaterSumTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    public TreeNode BstToGst(TreeNode root) {
        // 0,1,2,3,4,5,6,7,8
        // 0,  1, 3, 6,10,15,21,28,36
        // 0+36, 1+35, 2+33, 3+30, 4+25, 5+21, 6+15, 7+8, 8+0 
        // 36. , 36,     35,   33,   30,   26,   21,  15, 8
        return root;
    }
    public static TheoryData<TreeNode, TreeNode> TestData => new ()
    {
        {
            TreeNode.FromLevelOrderingIntArray([4,1,6,0,2,5,7,null,null,null,3,null,null,null,8])!, 
            TreeNode.FromLevelOrderingIntArray([30,36,21,36,35,26,15,null,null,null,33,null,null,null,8])!
        },
        {
            TreeNode.FromLevelOrderingIntArray([0,null,1])!, 
            TreeNode.FromLevelOrderingIntArray([1,null,1])!            
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, TreeNode expected)
    {
        var actual = BstToGst(input);
        AssertTreeNodeEqual(expected, actual);
    }
}

public class Q1305_AllElementsInTwoBST : TreeNodeTest
{
    public Q1305_AllElementsInTwoBST(ITestOutputHelper output) : base(output)
    {
    }

    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        return [];
    }

    public static TheoryData<TreeNode, TreeNode, IList<int>> TestData => new()
    {
        {
            TreeNode.FromLevelOrderingIntArray([2,1,4])!,
            TreeNode.FromLevelOrderingIntArray([1,0,3])!,
            [0, 1, 1, 2, 3, 4]
        },
        {
            TreeNode.FromLevelOrderingIntArray([1,null,8])!,
            TreeNode.FromLevelOrderingIntArray([8,1])!,
            [1, 1, 8, 8]
        },
    };
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode root1, TreeNode root2, IList<int> expected)
    {
        var actual = GetAllElements(root1, root2);
        Assert.Equal(expected, actual);
    }
}

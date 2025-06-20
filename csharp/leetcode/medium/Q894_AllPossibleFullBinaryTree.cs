
public class Q894_AllPossibleFullBinaryTree : TreeNodeTest
{
    public Q894_AllPossibleFullBinaryTree(ITestOutputHelper output) : base(output)
    {
    }

    public IList<TreeNode> AllPossibleFBT(int n)
    {
        return [];
    }
    public static TheoryData<int, IList<TreeNode>> TestData => new()
    {
        {7,  new List<TreeNode> {
            TreeNode.FromLevelOrderingIntArray([0,0,0,null,null,0,0,null,null,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,null,null,0,0,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,0,0,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,0,0,null,null,null,null,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,0,0,null,null,0,0])!
        }},
        {3, new List<TreeNode> {
            TreeNode.FromLevelOrderingIntArray([0,0,0])!
        }}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, IList<TreeNode> expected)
    {
        var actual = AllPossibleFBT(input);
        for (var i = 0; i < actual.Count; i++)
        {
            AssertTreeNodeEqual(expected[i], actual[i]);
        }
    }
}

public class Q2196_CreateBinaryTreeFromDescription : TreeNodeTest
{
    public Q2196_CreateBinaryTreeFromDescription(ITestOutputHelper output) : base(output)
    {
    }

    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        return new TreeNode();
    }
    public static TheoryData<int[][], TreeNode> TestData => new()
    {
        {[[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]], TreeNode.FromLevelOrderingIntArray([50,20,80,15,17,19])!},
        {[[1,2,1],[2,3,0],[3,4,1]], TreeNode.FromLevelOrderingIntArray([1,2,null,null,3,4])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, TreeNode expected)
    {
        var actual = CreateBinaryTree(input);
        Assert.Equal(expected, actual);
    }
}
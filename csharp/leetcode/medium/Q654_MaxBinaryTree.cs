public class Q654_MaxBinaryTree
{
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        return new();
    }
    public static TheoryData<int[], TreeNode> TestData => new()
    {
        {[3,2,1,6,0,5], TreeNode.FromLevelOrderingIntArray([6,3,5,null,2,0,null,null,1])!},
        {[3,2,1], TreeNode.FromLevelOrderingIntArray([3,null,2,null,1])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, TreeNode expected)
    {
        var actual = ConstructMaximumBinaryTree(input);
        Assert.Equal(expected, actual);
    }
}
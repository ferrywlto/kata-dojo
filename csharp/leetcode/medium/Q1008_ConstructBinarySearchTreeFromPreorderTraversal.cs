public class Q1008_ConstructBinarySearchTreeFromPreorderTraversal
{
    public TreeNode BstFromPreorder(int[] preorder)
    {
        return new();
    }
    public static TheoryData<int[], TreeNode> TestData => new()
    {
        {[8,5,1,7,10,12], TreeNode.FromLevelOrderingIntArray([8,5,10,1,7,null,12])!},
        {[1,3], TreeNode.FromLevelOrderingIntArray([1,null,3])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, TreeNode expected)
    {
        var actual = BstFromPreorder(input);
        Assert.Equal(expected, actual);
    }
}
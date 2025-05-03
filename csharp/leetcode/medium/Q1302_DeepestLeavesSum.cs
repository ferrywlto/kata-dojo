public class Q1302_DeepestLeavesSum
{
    public int DeepestLeavesSum(TreeNode root)
    {
        return 0;
    }
    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([1,2,3,4,5,null,6,7,null,null,null,null,8])!, 15},
        {TreeNode.FromLevelOrderingIntArray([6,7,8,2,7,1,3,9,null,1,4,null,null,null,5])!, 19},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, int expected)
    {
        var actual = DeepestLeavesSum(input);
        Assert.Equal(expected, actual);
    }
}
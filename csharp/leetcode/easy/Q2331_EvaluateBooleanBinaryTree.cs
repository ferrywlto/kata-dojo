public class Q2331_EvaluateBooleanBinaryTree
{
    public bool EvaluateTree(TreeNode root)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [new int?[] {2,1,3,null,null,0,1}, true],
        [new int?[] {0}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int?[] input, bool expected)
    {
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = EvaluateTree(tree!);
        Assert.Equal(expected, actual);
    }

}
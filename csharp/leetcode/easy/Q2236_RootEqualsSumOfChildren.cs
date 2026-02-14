public class Q2236_RootEqualsSumOfChildren
{
    // TC: O(1), obviously
    // SC: O(1), obviously
    public bool CheckTree(TreeNode root)
    {
        return root.val == root!.left!.val + root!.right!.val;
    }
    public static List<object[]> TestData =>
    [
        [new int?[] {10,4,6}, true],
        [new int?[] {5,3,1}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int?[] input, bool expected)
    {
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = CheckTree(tree!);
        Assert.Equal(expected, actual);
    }
}

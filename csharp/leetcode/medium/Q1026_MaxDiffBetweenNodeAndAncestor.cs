public class Q1026_MaxDiffBetweenNodeAndAncestor(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(d^2), d scale with depth of root
    // SC: O(d^2), each node holds all ancestors
    public int MaxAncestorDiff(TreeNode root)
    {
        var result = X(root, []);
        return result;
    }

    private int X(TreeNode? node, HashSet<int> ancestors)
    {
        if (node == null) return -1;

        var maxDiff = 0;
        foreach (var a in ancestors)
        {
            var diff = Math.Abs(node.val - a);
            if (Math.Abs(node.val - a) > maxDiff)
            {
                maxDiff = Math.Max(maxDiff, diff);
            }
        }
        var fromLeft = X(node.left, [.. ancestors, node.val]);
        var fromRight = X(node.right, [.. ancestors, node.val]);

        var maxDiffFromBelow = Math.Max(fromLeft, fromRight);
        return Math.Max(maxDiff, maxDiffFromBelow);
    }

    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([8,3,10,1,6,null,14,null,null,4,7,13])!, 7},
        {TreeNode.FromLevelOrderingIntArray([1,null,2,null,0,3])!, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode node, int expected)
    {
        var actual = MaxAncestorDiff(node);
        Assert.Equal(expected, actual);
    }
}

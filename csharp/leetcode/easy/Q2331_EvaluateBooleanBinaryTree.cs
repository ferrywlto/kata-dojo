public class Q2331_EvaluateBooleanBinaryTree
{
    // TC: O(n), n scale with number of nodes in root.
    // SC: O(d), d scale with depth of tree
    public bool EvaluateTree(TreeNode root)
    {
        return EvaluateNode(root);
    }
    public bool EvaluateNode(TreeNode node)
    {
        return node.val switch
        {
            0 => false,
            1 => true,
            2 => EvaluateNode(node.left!) || EvaluateNode(node.right!),
            3 => EvaluateNode(node.left!) && EvaluateNode(node.right!),
            _ => throw new NotImplementedException(),
        };
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

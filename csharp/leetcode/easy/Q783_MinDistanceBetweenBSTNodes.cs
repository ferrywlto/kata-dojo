public class Q783_MinDistanceBetweenBSTNodes
{
    // TC: O(n)
    // SC: O(h)
    // Use the same inorder traversal technique as in Q530
    public int MinDiffInBST(TreeNode root)
    {
        var minDiff = int.MaxValue;
        var stack = new Stack<TreeNode>();

        TreeNode? current = root;
        TreeNode? prev = null;
        var result = new List<int>();
        while (current != null || stack.Count > 0)
        {
            // Down to deepest left first
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            if (prev != null)
            {
                // Since BST with inorder traversal -> sorted 
                minDiff = Math.Min(minDiff, current.val - prev.val);
            }
            prev = current;

            result.Add(current.val);
            current = current.right;
        }
        return minDiff;
    }
}

public class Q783_MinDistanceBetweenBSTNodesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {4,2,6,1,3}, 1],
        [new int?[] {1,0,48,null,null,12,49}, 1],
        [new int?[] {90,69,null,49,89,null,52}, 1],
    ];
}

public class Q783_MinDistanceBetweenBSTNodesTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q783_MinDistanceBetweenBSTNodesTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q783_MinDistanceBetweenBSTNodes();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        DebugTree(tree!);
        var actual = sut.MinDiffInBST(tree!);
        Assert.Equal(expected, actual);
    }
}
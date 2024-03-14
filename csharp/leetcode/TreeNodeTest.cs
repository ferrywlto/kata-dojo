namespace dojo.leetcode;

public abstract class TreeNodeTest : BaseTest
{
    [Fact]
    public void ShouldEqualOnPerfectTree()
    {
        var expected = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(4),
                new TreeNode(5)
            ),
            new TreeNode(3,
                new TreeNode(6),
                new TreeNode(7)
            )
        );
        int?[] input = [1, 2, 3, 4, 5, 6, 7];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnTrailingNulls()
    {
        var expected = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(4),
                new TreeNode(5)
            ),
            new TreeNode(3,
                new TreeNode(6),
                new TreeNode(7)
            )
        );
        int?[] input = [1, 2, 3, 4, 5, 6, 7, null, null];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnMissingRightNodes()
    {
        var expected = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(4)
            ),
            new TreeNode(3,
                new TreeNode(6)
            )
        );
        int?[] input = [1, 2, 3, 4, null, 6, null];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnMissinLeftNodes()
    {
        var expected = new TreeNode(1,
            new TreeNode(2,
                null,
                new TreeNode(5)
            ),
            new TreeNode(3,
                null,
                new TreeNode(7)
            )
        );
        int?[] input = [1, 2, 3, null, 5, null, 7];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnUnbalancedTree()
    {
        var expected = new TreeNode(1,
            null,
            new TreeNode(2,
                new TreeNode(3)
            )
        );
        int?[] input = [1, null, 2, 3];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnMissingBothLeftAndRightNodes()
    {
        var expected = new TreeNode(1,
            new TreeNode(2,
                null,
                new TreeNode(3)
            )
        );
        int?[] input = [1, 2, null, null, 3];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
        // AssertTreeNodeEqual_Loop(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnSingleNodeTree()
    {
        var expected = new TreeNode(1);
        int?[] input = [1];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnNullOnly()
    {
        TreeNode? expected = null;
        int?[] input = [];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
    }

    public TreeNodeTest() {}
    public TreeNodeTest(ITestOutputHelper output) : base(output) {}

    protected void AssertTreeNodeEqual(TreeNode? expected, TreeNode? actual)
    {
        if (expected == null && actual == null) return;
        
        Assert.Equal(expected?.val, actual?.val);
        AssertTreeNodeEqual(expected?.left, actual?.left);
        AssertTreeNodeEqual(expected?.right, actual?.right);
    }

    // Demonstration purpose of not using recursion.
    protected void AssertTreeNodeEqual_Loop(TreeNode expected, TreeNode actual)
    {
        var expectedQ = new Queue<TreeNode?>();
        var actualQ = new Queue<TreeNode?>();

        expectedQ.Enqueue(expected);
        actualQ.Enqueue(actual);

        while(expectedQ.Count > 0 && actualQ.Count > 0) {
            // early termination if structure is not the same (i.e. one tree has subtee while the other doesn't)
            Assert.Equal(expectedQ.Count, actualQ.Count);

            var expectedCurrent = expectedQ.Dequeue();
            var actualCurrent = actualQ.Dequeue();

            if (expectedCurrent == null && actualCurrent == null) break;

            Assert.Equal(expectedCurrent?.val, actualCurrent?.val);

            expectedQ.Enqueue(expectedCurrent?.left);
            expectedQ.Enqueue(expectedCurrent?.right);

            actualQ.Enqueue(actualCurrent?.left);
            actualQ.Enqueue(actualCurrent?.right);
        }
    }

    protected void DebugTree(TreeNode root)
    {
        if (Output == null) 
            throw new Exception("Pass ITestOutputHelper in constructor first!");

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            Output!.WriteLine($"node.val: {node.val}, left: {node.left?.val.ToString() ?? "null"}, right: {node.right?.val.ToString() ?? "null"}");
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }
    }
}

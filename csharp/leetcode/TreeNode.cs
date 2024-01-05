public class TreeNodeTests
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
        // AssertTreeNodeEqual_Loop(expected, actual);
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
        // AssertTreeNodeEqual_Loop(expected, actual);
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
        // AssertTreeNodeEqual_Loop(expected, actual);
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
        // AssertTreeNodeEqual_Loop(expected, actual);
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
        // AssertTreeNodeEqual_Loop(expected, actual);
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
        // AssertTreeNodeEqual_Loop(expected, actual);
    }

    [Fact]
    public void ShouldEqualOnNullOnly()
    {
        TreeNode? expected = null;
        int?[] input = [];
        var actual = TreeNode.FromLevelOrderingIntArray(input);
        AssertTreeNodeEqual(expected, actual);
        // AssertTreeNodeEqual_Loop(expected, actual);
    }


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
}

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
    public bool IsLeaf => left == null && right == null;
    

    // From Q100 & Q101, actually the input is in level order.
    // That means from top-to-down, left-to-right
    // [root, left, right, left-of-left. right-of-right, left-of-right, right-of-right, ...]
    // [1,null,2,3] => 
    //    1 
    //   / \ 
    // null 2
    //     / \
    //    3  null
    //   / \
    // null null 

    public static TreeNode? FromLevelOrderingIntArray(int?[] input)
    {
        if (input.Length == 0 || input[0] == null)
        {
            return null;
        }
        var root = new TreeNode(input[0] ?? int.MinValue);
        if (input.Length == 1)
        {
            return root;
        }

        // Using queue is critical
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        // Construct the tree from root
        int idx = 0;
        while (idx < input.Length)
        {
            var parent = queue.Dequeue();

            // Assign left child
            if (++idx < input.Length && input[idx] != null)
            {
                parent.left = new TreeNode(input[idx] ?? int.MinValue);
                queue.Enqueue(parent.left);
            }

            // Assign right child
            if (++idx < input.Length && input[idx] != null)
            {
                parent.right = new TreeNode(input[idx] ?? int.MinValue);
                queue.Enqueue(parent.right);
            }
        }
        return root;
    }
}

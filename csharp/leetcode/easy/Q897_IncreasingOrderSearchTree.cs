class Q897_IncreasingOrderSearchTree
{
    public TreeNode IncreasingBST(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var queue = new Queue<TreeNode>();
        TreeNode? current = root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            queue.Enqueue(current);
            current = current.right;
        }

        var head = queue.Dequeue();
        var prev = head;
        prev.left = null;
        prev.right = null;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            node.left = null;
            node.right = null;

            prev.right = node;
            prev = node;
        }
        return head;
    }
}

class Q897_IncreasingOrderSearchTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int?[] {5,3,6,2,4,null,8,1,null,null,null,7,9},
            new int?[] {1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9},
        ],
        [
            new int?[]{5,1,7},
            new int?[]{1,null,5,null,7},
        ],
        [
            new int?[]{1},
            new int?[]{1},
        ],
        [
            new int?[]{1, null, 2},
            new int?[]{1, null, 2},
        ],
        [
            new int?[]{2,1},
            new int?[]{1, null, 2},
        ],
    ];
}

public class Q897_IncreasingOrderSearchTreeTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q897_IncreasingOrderSearchTreeTestData))]
    public void OfficialTestCases(int?[] input, int?[] expected)
    {
        var sut = new Q897_IncreasingOrderSearchTree();
        var inputTree = TreeNode.FromLevelOrderingIntArray(input);
        var expectedTree = TreeNode.FromLevelOrderingIntArray(expected);
        var actualTree = sut.IncreasingBST(inputTree!);
        DebugTree(actualTree);
        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}
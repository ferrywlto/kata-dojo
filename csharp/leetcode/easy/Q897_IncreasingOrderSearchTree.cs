class Q897_IncreasingOrderSearchTree
{
    // TC: O(n), n is total nodes in input tree
    // SC: O(h), h is height of tree
    public TreeNode IncreasingBST(TreeNode root)
    {
        var dummy = new TreeNode();
        var current = dummy;
        var stack = new Stack<TreeNode>();
        TreeNode? node = root;

        while (node != null || stack.Count > 0)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }

            node = stack.Pop();
            node.left = null;
            current.right = node;
            current = node;

            node = node.right;
        }

        // The technique here is we don't care what is before the returned node, so it doesn't matter what dummy actually is
        return dummy.right!;
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
namespace dojo.leetcode;

public class Q572_SubtreeOfAnotherTree
{
    // find the node with in root tree that have val == subroot.val
    // do a double tree traverse in same node, if in any step the node value is not equal, return false;
    // return true if all nodes values are the same
    // TC: O(n)
    // SC: O(n)
    public bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        if (root == null || subRoot == null) return false;
        //get the node that is the root of subroot
        var stack = new Stack<TreeNode>();
        stack.Push(root!);

        TreeNode? nodeOfSubRoot = null;
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node.val == subRoot.val)
            {
                nodeOfSubRoot = node;
                Console.WriteLine($"node found: root:{node.val}, sub:{subRoot.val}");
                break;
            }
            if (node.left != null)
            {
                stack.Push(node.left);
            }
            if (node.right != null)
            {
                stack.Push(node.right);
            }
        }

        if (nodeOfSubRoot == null)
        {
            return false;
        }

        var parallelStack = new Stack<(TreeNode nodeFromRoot, TreeNode nodeFromSubRoot)>();
        parallelStack.Push((nodeOfSubRoot, subRoot));

        while (parallelStack.Count > 0)
        {
            var (nodeFromRoot, nodeFromSubRoot) = parallelStack.Pop();
            Console.WriteLine($"parallel: root:{nodeFromRoot.val}, sub:{nodeFromSubRoot.val}");
            if(nodeFromRoot.val != nodeFromSubRoot.val)
            {
                return false;
            }

            if(nodeFromRoot.left != null && nodeFromSubRoot.left != null)
            {
                parallelStack.Push((nodeFromRoot.left, nodeFromSubRoot.left));
            }
            else if (nodeFromRoot.left != null || nodeFromSubRoot.left != null)
            {
                return false;
            }

            if (nodeFromRoot.right != null && nodeFromSubRoot.right != null)
            {
                parallelStack.Push((nodeFromRoot.right, nodeFromSubRoot.right));
            }
            else if(nodeFromRoot.right != null || nodeFromSubRoot.right != null)
            {
                return false;
            }
        }

        return true;
    }
}

public class Q572_SubtreeOfAnotherTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {3, 4, 5, 1, 2}, new int?[] {4, 1, 2}, true],
        [new int?[] {3, 4, 5, 1, 2, null, null, null, null, 0}, new int?[] {4, 1, 2}, false],
    ];
}

public class Q572_SubtreeOfAnotherTreeTests
{
    [Theory]
    [ClassData(typeof(Q572_SubtreeOfAnotherTreeTestData))]
    public void OfficialTestCases(int?[] root, int?[] subRoot, bool expected)
    {
        var sut = new Q572_SubtreeOfAnotherTree();
        var rootTree = TreeNode.FromLevelOrderingIntArray(root);
        var subRootTree = TreeNode.FromLevelOrderingIntArray(subRoot);
        var actual = sut.IsSubtree(rootTree, subRootTree);
        Assert.Equal(expected, actual);
    }
}
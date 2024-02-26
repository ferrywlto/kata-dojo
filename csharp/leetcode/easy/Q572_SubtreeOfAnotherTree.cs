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
        
        var traverseStack = new Stack<TreeNode>();
        traverseStack.Push(root);

        while (traverseStack.Count > 0)
        {
            var node = traverseStack.Pop();
            if (node.val == subRoot.val && CompareTreeEqual(node, subRoot)) return true;

            if (node.left != null) traverseStack.Push(node.left);

            if (node.right != null) traverseStack.Push(node.right);
        }

        return false;
    }
    public bool CompareTreeEqual(TreeNode inputTree, TreeNode targetTree)
    {
        var parallelStack = new Stack<(TreeNode nodeFromRoot, TreeNode nodeFromSubRoot)>();
        parallelStack.Push((inputTree, targetTree));

        while (parallelStack.Count > 0)
        {
            var (nodeFromRoot, nodeFromSubRoot) = parallelStack.Pop();
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
        [new int?[] {1, 1}, new int?[] {1}, true],
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
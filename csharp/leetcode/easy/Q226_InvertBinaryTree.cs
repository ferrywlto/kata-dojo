public class Q226_InvertBinaryTree
{
    public TreeNode? InvertTree(TreeNode? root) 
    {
        if (root == null) return null;
        Invert(root);
        return root;    
    }
    // TC:O(n), SC:O(n)
    public void Invert(TreeNode? node) 
    {
        if (node == null) return;

        Invert(node.left);
        Invert(node.right);

        (node.left, node.right) = (node.right, node.left);
    }

    // TC:O(n), SC:O(1)
    public TreeNode? InvertTree_Iterative(TreeNode? root) 
    {
        if (root == null) return null;

        Stack<TreeNode> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            (node.right, node.left) = (node.left, node.right);
            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }

        return root;
    }
}

public class Q226_InvertBinaryTreeTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{4,2,7,1,3,6,9}, new int[]{4,7,2,9,6,3,1}],
        [new int[]{2,1,3}, new int[]{2,3,1}],
        [Array.Empty<int>(), Array.Empty<int>()],
    ];
}

public class Q226_InvertBinaryTreeTests: TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q226_InvertBinaryTreeTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q226_InvertBinaryTree();
        var inputConverted = Array.ConvertAll<int, int?>(input, x => x);
        var expectedConverted = Array.ConvertAll<int, int?>(expected, x => x);

        var expectedTree = TreeNode.FromLevelOrderingIntArray(expectedConverted);
        var tree = TreeNode.FromLevelOrderingIntArray(inputConverted);
        var actualTree = sut.InvertTree_Iterative(tree);

        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}

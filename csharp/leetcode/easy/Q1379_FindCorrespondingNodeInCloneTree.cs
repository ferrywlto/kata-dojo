class Q1379_FindCorrespondingNodeInCloneTree
{
    // TC: O(n), as n need to traverse once in original and once in cloned, thus 2n -> n
    // SC: O(h), stack need to store all nodes if tree is skewed worst case
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
    {
        // only 0 or 1, 0 means left, 1 means right
        string resultPath = string.Empty;
        var stack = new Stack<(TreeNode node, string path)>();
        stack.Push((original, string.Empty));
        while(stack.Count > 0 && string.IsNullOrEmpty(resultPath))
        {
            var (node, path) = stack.Pop();
            if(ReferenceEquals(node, target)) resultPath = path;
            if(node.right != null) stack.Push((node.right, path+"1"));
            if(node.left != null) stack.Push((node.left, path+"0"));
        }
        TreeNode? clonedNode = cloned;
        foreach(var choice in resultPath)
        {
            if (choice == '0') clonedNode = clonedNode?.left;
            else clonedNode = clonedNode?.right;
        }
        return clonedNode!;
    }
    public TreeNode GetNodeReferenceFromValue(TreeNode tree, int value)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(tree);
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            if(node.val == value) return node;
            if(node.right != null) stack.Push(node.right);
            if(node.left != null) stack.Push(node.left);
        }
        return tree;
    }
    public TreeNode GetNodeFromPath(TreeNode tree, string path)
    {
        TreeNode? node = tree;
        foreach(var choice in path)
        {
            if (choice == '0') node = node?.left;
            else node = node?.right;
        }
        return node!;
    }
}
class Q1379_FindCorrespondingNodeInCloneTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{7,4,3,null,null,6,19}, 3, 3],
        [new int?[]{7}, 7, 7],
        [new int?[]{8,null,6,null,5,null,4,null,3,null,2,null,1}, 4, 4],
    ];
}
public class Q1379_FindCorrespondingNodeInCloneTreeTest : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q1379_FindCorrespondingNodeInCloneTreeTestData))]
    public void OfficialTestCases(int?[] input, int target, int expected)
    {
        var sut = new Q1379_FindCorrespondingNodeInCloneTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var targetNode = sut.GetNodeReferenceFromValue(tree!, target);
        var clone = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.GetTargetCopy(tree!, clone!, targetNode);
        Assert.Equal(expected, actual.val);
    }

    [Fact]
    public void GetTargetCopy_ReturnCorrectNode_OnDuplicateNumber()
    {
        var sut = new Q1379_FindCorrespondingNodeInCloneTree();
        var input = new int?[] { 8, null, 6, null, 5, null, 4, null, 3, null, 2, null, 1, 2, 1 };
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var path = "1111110";
        var targetNode = sut.GetNodeFromPath(tree!, path);
        Assert.Equal(2, targetNode.val);
        var node = tree?.right?.right?.right?.right?.right?.right?.left;
        Assert.True(ReferenceEquals(node, targetNode));
        var cloned = TreeNode.FromLevelOrderingIntArray(input);
        var clonedNode = sut.GetTargetCopy(tree!, cloned!, targetNode);
        Assert.Equal(targetNode.val, clonedNode.val);
    }
}
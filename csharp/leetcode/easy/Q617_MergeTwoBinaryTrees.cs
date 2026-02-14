class Q617_MergeTwoBinaryTrees
{
    // TC: O(n)
    // SC: O(n)
    public TreeNode? MergeTrees(TreeNode? root1, TreeNode? root2)
    {
        // use parallel stack technique
        var mergedTree = MergeNode(root1, root2);
        var parallelStack = new Stack<(TreeNode? tree1, TreeNode? tree2, TreeNode? merged)>();
        parallelStack.Push((root1, root2, mergedTree));

        while (parallelStack.Count > 0)
        {
            var (tree1, tree2, merged) = parallelStack.Pop();

            if (merged != null)
            {
                var mergedLeft = MergeNode(tree1?.left, tree2?.left);
                merged.left = mergedLeft;
                parallelStack.Push((tree1?.left, tree2?.left, mergedLeft));

                var mergedRight = MergeNode(tree1?.right, tree2?.right);
                merged.right = mergedRight;
                parallelStack.Push((tree1?.right, tree2?.right, mergedRight));
            }
        }

        return mergedTree;
    }

    public TreeNode? MergeNode(TreeNode? node1, TreeNode? node2)
    {
        if (node1 == null && node2 == null) return null;
        return new TreeNode((node1?.val ?? 0) + (node2?.val ?? 0));
    }
}

class Q617_MergeTwoBinaryTreesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1,3,2,5}, new int?[]{2,1,3,null,4,null,7}, new int?[]{3,4,5,5,4,null,7}],
        [new int?[]{1}, new int?[]{1,2}, new int?[]{2,2}],
    ];
}

public class Q617_MergeTwoBinaryTreesTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q617_MergeTwoBinaryTreesTestData))]
    public void OfficialTestCases(int?[] input1, int?[] input2, int?[] expected)
    {
        var sut = new Q617_MergeTwoBinaryTrees();
        var tree1 = TreeNode.FromLevelOrderingIntArray(input1);
        var tree2 = TreeNode.FromLevelOrderingIntArray(input2);
        var treeExpected = TreeNode.FromLevelOrderingIntArray(expected);
        var treeActual = sut.MergeTrees(tree1, tree2);

        AssertTreeNodeEqual_Loop(treeExpected!, treeActual!);
    }
}

class Q530_MinimumAbsoluteDifferenceInBST
{
    public int GetMinimumDifference(TreeNode root)
    {
        if (root.IsLeaf) return 0;

        TreeNode? current = root;
        TreeNode? prev = null;

        var smallest = int.MaxValue;
        var stack = new Stack<TreeNode>();
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
                smallest = Math.Min(smallest, current.val - prev.val);
            }
            prev = current;

            result.Add(current.val);
            current = current.right;
        }

        for (var i = 0; i < result.Count - 1; i++)
        {
            var diff = Math.Abs(result[i] - result[i + 1]);
            if (diff < smallest)
                smallest = diff;
        }
        return smallest;
    }
}

class Q530_MinimumAbsoluteDifferenceInBSTTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1,0,48,null,null,12,49}, 1],
        [new int?[]{4,2,6,1,3}, 1],
        [new int?[]{236,104,701,null,227,null,911}, 9],
    ];
}

public class Q530_MinimumAbsoluteDifferenceInBSTTests
{
    [Theory]
    [ClassData(typeof(Q530_MinimumAbsoluteDifferenceInBSTTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q530_MinimumAbsoluteDifferenceInBST();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.GetMinimumDifference(tree!);
        Assert.Equal(expected, actual);
    }
}

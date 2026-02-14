class Q997_CousinsInBinaryTree
{
    // TC: O(n), n is nodes in tree
    // SC: O(n+h), n nodes in tree + h height of stack
    public bool IsCousins(TreeNode root, int x, int y)
    {
        var dict = new Dictionary<int, (int? parent, int height)>();
        var stack = new Stack<(TreeNode node, int height)>();
        stack.Push((root, 0));
        dict.Add(root.val, (null, 0));

        while (stack.Count > 0)
        {
            var (node, height) = stack.Pop();
            if (node.right != null)
            {
                dict.Add(node.right.val, (node.val, height + 1));
                stack.Push((node.right, height + 1));
            }
            if (node.left != null)
            {
                dict.Add(node.left.val, (node.val, height + 1));
                stack.Push((node.left, height + 1));
            }
            if (dict.TryGetValue(x, out var nodeX) && dict.TryGetValue(y, out var nodeY))
            {
                return nodeX.height == nodeY.height && nodeX.parent != nodeY.parent;
            }
        }
        return false;
    }
}

class Q997_CousinsInBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1,2}, 1, 2, false],
        [new int?[]{1,2}, 1, 3, false],
        [new int?[]{1,null, 2}, 1, 2, false],
        [new int?[]{1,2,3,4}, 4, 3, false],
        [new int?[]{1,2,3,null,4,null,5}, 5, 4, true],
        [new int?[]{1,2,3,null,4}, 2, 3, false],
    ];
}

public class Q997_CousinsInBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q997_CousinsInBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int x, int y, bool expected)
    {
        var sut = new Q997_CousinsInBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsCousins(tree!, x, y);
        Assert.Equal(expected, actual);
    }
}

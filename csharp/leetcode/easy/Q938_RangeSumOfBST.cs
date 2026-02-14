class Q938_RangeSumOfBST
{
    // TC: O(n), n is nodes in tree
    // SC: O(h), h is height of tree
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        var result = 0;
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        // cannot use inorder traveral, need to manual control with DFS in order to prune tree
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node != null)
            {
                if (node.val > low && node.left != null)
                {
                    stack.Push(node.left);
                }
                if (node.val < high && node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.val >= low && node.val <= high)
                {
                    result += node.val;
                }
            }
        }

        return result;
    }
}

class Q938_RangeSumOfBSTTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{10,5,15,3,7,null,18}, 7, 15, 32],
        [new int?[]{10,5,15,3,7,13,18,1,null,6}, 6, 10, 23],
    ];
}

public class Q938_RangeSumOfBSTTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q938_RangeSumOfBSTTestData))]
    public void OfficialTestCases(int?[] input, int low, int high, int expected)
    {
        var sut = new Q938_RangeSumOfBST();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.RangeSumBST(tree!, low, high);
        Assert.Equal(expected, actual);
    }
}

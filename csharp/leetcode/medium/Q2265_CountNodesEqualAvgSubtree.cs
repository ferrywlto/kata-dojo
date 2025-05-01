public class Q2265_CountNodesEqualAvgSubtree
{
    private int _resultCount = 0;
    // TC: O(n), all nodes just need to iterate once
    // SC: O(1), space used does not scale with input
    public int AverageOfSubtree(TreeNode root)
    {
        CalSubtree(root);
        return _resultCount;
    }
    private (int count, int sum) CalSubtree(TreeNode? input)
    {
        if (input == null) return (0, 0);

        var left = CalSubtree(input.left);
        var right = CalSubtree(input.right);
        var sumNodes = input.val + left.sum + right.sum;
        var numNodes = 1 + left.count + right.count;
        var avg = sumNodes / numNodes;

        if (input.val == avg) _resultCount++;
        return (numNodes, sumNodes);
    }
    public static TheoryData<TreeNode, int> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([4,8,5,0,1,null,6])!, 5},
        {TreeNode.FromLevelOrderingIntArray([1])!, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, int expected)
    {
        var actual = AverageOfSubtree(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2265_CountNodesEqualAvgSubtree//(ITestOutputHelper output)
{
    private int _resultCount = 0;
    // TC: O(n), all nodes just need to iterate once
    // SC: O(1), space used does not scale with input
    public int AverageOfSubtree(TreeNode root)
    {
        CalSubtree(root);
        return _resultCount;
    }
    private (int, int) CalSubtree(TreeNode input)
    {
        var numNodes = 1;
        var sumNodes = input.val;
        if (input.left != null)
        {
            var (s, n) = CalSubtree(input.left);
            sumNodes += s;
            numNodes += n;
        }
        if (input.right != null)
        {
            var (s, n) = CalSubtree(input.right);
            sumNodes += s;
            numNodes += n;
        }
        var avg = sumNodes / numNodes;
        // output.WriteLine("node: {0}, n: {1}, s: {2}, avg: {3}", input.val, numNodes, sumNodes, avg);

        if (input.val == avg) _resultCount++;
        return (sumNodes, numNodes);
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
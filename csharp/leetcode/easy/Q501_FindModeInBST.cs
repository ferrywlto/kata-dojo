class Q501_FindModeInBST
{
    // TC: O(n) as have to traverse each node at least once
    // SC: O(n) as dictionary size = number of nodes in worst case 
    public int[] FindMode(TreeNode root)
    {
        if (root.left == null && root.right == null)
            return [root.val];

        var demography = new Dictionary<int, int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (demography.ContainsKey(node.val))
            {
                demography[node.val]++;
            }
            else
            {
                demography.Add(node.val, 1);
            }

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }

        var mode = demography.Max(x => x.Value);

        return demography
            .Where(x => x.Value == mode)
            .Select(x => x.Key)
            .ToArray();
    }
}

class Q501_FindModeInBSTTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new TreeNode(1, null, new TreeNode(2, new TreeNode(2), null)), new int[] {2}],
        [new TreeNode(1, null, new TreeNode(2, new TreeNode(2), new TreeNode(3))), new int[] {2}],
        [new TreeNode(1, null, new TreeNode(2, new TreeNode(2), new TreeNode(3, new TreeNode(3), null))), new int[] {2, 3}],
    ];
}

public class Q501_FindModeInBSTTests
{
    [Theory]
    [ClassData(typeof(Q501_FindModeInBSTTestData))]
    public void OfficialTestCases(TreeNode root, int[] expected)
    {
        var sut = new Q501_FindModeInBST();
        var actual = sut.FindMode(root);
        Array.Sort(expected);
        Array.Sort(actual);
        Assert.Equal(expected, actual);
    }
}

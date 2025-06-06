public class FindElements
{
    // Fastest solution make use of bitArray and the constaints 10^6, not bother here as current solution is good enough
    private HashSet<int> _vals = [];
    public FindElements(TreeNode root)
    {
        root.val = 0;
        _vals.Add(0);
        Recover(root);
    }
    private void Recover(TreeNode? node)
    {
        if (node == null) return;
        if (node.left != null)
        {
            var val = (node.val * 2) + 1;
            node.left.val = val;
            _vals.Add(val);
            Recover(node.left);
        }
        if (node.right != null)
        {
            var val = (node.val * 2) + 2;
            node.right.val = val;
            _vals.Add(val);
            Recover(node.right);
        }
    }
    public bool Find(int target) => _vals.Contains(target);
}
public class Q1261_FindElementsInContaminatedBinaryTree
{
    public static TheoryData<TreeNode, List<int>, List<bool>> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([-1,null,-1])!, [1,2], [false, true]},
        {TreeNode.FromLevelOrderingIntArray([-1,-1,-1,-1,-1])!, [1,3,5], [true, true, false]},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode tree, List<int> input, List<bool> expected)
    {
        var q = new FindElements(tree);
        for (var i = 0; i < input.Count; i++)
        {
            var actual = q.Find(input[i]);
            Assert.Equal(expected[i], actual);
        }
    }
}
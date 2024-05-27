class Q653_TwoSumIV
{
    // TC: O(n)
    // SC: O(n)
    public bool FindTarget(TreeNode root, int k) 
    {
        var hashset = new HashSet<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while(stack.Count > 0)
        {
            var node = stack.Pop();
            if(hashset.Contains(k-node.val)) return true;
            else hashset.Add(node.val);

            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }
        return false;    
    }
}

class Q653_TwoSumIVTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[] {5,3,6,2,4,null,7}, 9, true],
        [new int?[] {5,3,6,2,4,null,7}, 28, false],
    ];
}

public class Q653_TwoSumIVTests : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q653_TwoSumIVTestData))]
    public void OfficialTestCases(int?[] input, int k, bool expected)
    {
        var sut = new Q653_TwoSumIV();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.FindTarget(tree!, k);
        Assert.Equal(expected, actual);
    }
}
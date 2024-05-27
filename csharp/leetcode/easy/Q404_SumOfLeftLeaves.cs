class Q404_SumOfLeftLeaves
{
    // TC: O(n), SC: O(n)
    public int SumOfLeftLeaves(TreeNode? root)
    {
        var result = 0;        
        var stack = new Stack<TreeNode>();
        
        if (root != null) stack.Push(root);

        while(stack.Count > 0)
        {
            var node = stack.Pop();
            if(node.left != null && node.left.IsLeaf) 
            {
                result += node.left.val;
            }
            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }
        return result;
    }
}

class Q404_SumOfLeftLeavesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{3,9,20,null,null,15,7},24],
        [new int?[]{1},0],
    ];
}

public class Q404_SumOfLeftLeavesTests
{
    [Theory]
    [ClassData(typeof(Q404_SumOfLeftLeavesTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q404_SumOfLeftLeaves();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.SumOfLeftLeaves(tree);
        Assert.Equal(expected, actual);
    }
}

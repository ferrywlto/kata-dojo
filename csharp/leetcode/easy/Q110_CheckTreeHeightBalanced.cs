namespace dojo.leetcode;

public class Q110_CheckTreeHeightBalanced
{
    record HeightRecord(TreeNode Node, int LeftHeight, int RightHeight) 
    {
        public bool HeightBalanced => Math.Abs(LeftHeight - RightHeight) <= 1;
    } 
    
    public bool IsBalanced(TreeNode? root)
    {
        if (root == null || root.IsLeaf) return true;

        var records = new List<HeightRecord>();
        var stack = new Stack<TreeNode>();
        
        stack.Push(root);
        while(stack.Count > 0)
        {
            var node = stack.Pop();

            if(node.IsLeaf) 
            {
                records.Add(new HeightRecord(node, 0, 0));
            }
            var leftHeight = 0;
            var rightHeight = 0;
            if(node.left != null)
            {
                stack.Push(node.left);
                leftHeight = GetHeight(node.left);
            } 
            if(node.right != null)
            {
                stack.Push(node.right);
                rightHeight = GetHeight(node.right);
            }

            var record = new HeightRecord(node, leftHeight, rightHeight);
            if (!record.HeightBalanced) return false;
            records.Add(record);
        }
        return true;
    }

    public int GetHeight(TreeNode? node)
    {
        if (node == null) return 0;
        if (node.IsLeaf) return 1;
        return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
    }
}

public class Q110_CheckTreeHeightBalancedTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {3,9,20,null,null,15,7}, true],
        [new int?[] {1,2,2,3,3,null,null,4,4}, false],
        [Array.Empty<int?>(), true],
        [new int?[]{1,null,2,null,3}, false],
        [new int?[]{1,2,2,3,null,null,3,4,null,null,4}, false],
    ];
}

public class Q110_CheckTreeHeightBalancedTests(ITestOutputHelper output) : BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q110_CheckTreeHeightBalancedTestData))]
    public void OfficialTestCases(int?[] input, bool expected)
    {
        var sut = new Q110_CheckTreeHeightBalanced();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsBalanced(tree!);
        Assert.Equal(expected, actual);
    }
}
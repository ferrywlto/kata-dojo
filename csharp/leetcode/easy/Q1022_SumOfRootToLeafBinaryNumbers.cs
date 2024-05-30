class Q1022_SumOfRootToLeafBinaryNumbers
{
    public int SumRootToLeaf(TreeNode root)
    {
        var result = 0;
        var stack = new Stack<(TreeNode node, int current)>();
        stack.Push((root, 0));
        while(stack.Count > 0)
        {
            var (node, current) = stack.Pop();
            var newCurrent = current * 2 + node.val;

            if(node.left == null && node.right == null)
            {
                result += newCurrent;
            }
            else
            {
                if(node.left != null) 
                {
                    stack.Push((node.left, newCurrent));
                }
                if(node.right != null)
                {
                    stack.Push((node.right, newCurrent));
                }
            }
        }
        return result;
    }
}

class Q1022_SumOfRootToLeafBinaryNumbersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1,0,1,0,1,0,1}, 22],
        [new int?[]{0}, 0],
    ];
}

public class Q1022_SumOfRootToLeafBinaryNumbersTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q1022_SumOfRootToLeafBinaryNumbersTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q1022_SumOfRootToLeafBinaryNumbers();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        DebugTree(tree!);
        var actual = sut.SumRootToLeaf(tree!);
        Assert.Equal(expected, actual);
    }
}
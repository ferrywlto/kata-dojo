namespace dojo.leetcode;

public class Q543_DiameterOfBinaryTree
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        return 0;
    }
}

public class Q543_DiameterOfBinaryTreeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[] {1,2,3,4,5}, 3],
        [new int?[] {1,2}, 2],
    ];
}

public class Q543_DiameterOfBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q543_DiameterOfBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q543_DiameterOfBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.DiameterOfBinaryTree(tree!);
        Assert.Equal(expected, actual);
    }
}
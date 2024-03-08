
namespace dojo.leetcode;

public class Q671_SecondMinNodeInBinaryTree
{
    public int FindSecondMinimumValue(TreeNode root) 
    {
        return 0;    
    }
}

public class Q671_SecondMinNodeInBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {2,2,5,null,null,5,7}, 5],
        [new int?[] {2,2,2}, -1],
    ];
}

public class Q671_SecondMinNodeInBinaryTreeTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q671_SecondMinNodeInBinaryTreeTestData))]
    public void OfficicalTestCases(int?[] input, int expected)
    {
        var sut = new Q671_SecondMinNodeInBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.FindSecondMinimumValue(tree!);
        Assert.Equal(expected, actual);
    }
}
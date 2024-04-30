
class Q965_UnivaluedBinaryTree
{
        public bool IsUnivalTree(TreeNode root) {
        return false;   
    }
}

class Q965_UnivaluedBinaryTreeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[] {1,1,1,1,1,null,1}, true],
        [new int?[] {2,2,2,5,2}, false],
    ];
}

public class Q965_UnivaluedBinaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q965_UnivaluedBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, bool expected)
     {
        var sut = new Q965_UnivaluedBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsUnivalTree(tree!);
        Assert.Equal(expected, actual);
     }
}
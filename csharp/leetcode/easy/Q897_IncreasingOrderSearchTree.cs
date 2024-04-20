
class Q897_IncreasingOrderSearchTree
{
    public TreeNode IncreasingBST(TreeNode root) 
    {
        return new TreeNode();    
    }
}

class Q897_IncreasingOrderSearchTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int?[] {5,3,6,2,4,null,8,1,null,null,null,7,9},
            new int?[] {1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9},
        ],
        [
            new int?[]{5,1,7},
            new int?[]{1,null,5,null,7},
        ]
    ];
}

public class Q897_IncreasingOrderSearchTreeTests : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q897_IncreasingOrderSearchTreeTestData))]
    public void OfficialTestCases(int?[] input, int?[] expected)
    {
        var sut = new Q897_IncreasingOrderSearchTree();
        var inputTree = TreeNode.FromLevelOrderingIntArray(input);
        var expectedTree = TreeNode.FromLevelOrderingIntArray(expected);
        var actualTree = sut.IncreasingBST(inputTree!);
        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}
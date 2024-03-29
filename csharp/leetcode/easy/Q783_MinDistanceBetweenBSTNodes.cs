
namespace dojo.leetcode;

public class Q783_MinDistanceBetweenBSTNodes
{
    public int MinDiffInBST(TreeNode root) 
    {
        return 0;    
    }
}

public class Q783_MinDistanceBetweenBSTNodesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {4,2,6,1,3}, 1],
        [new int?[] {1,0,48,null,null,12,49}, 1],
    ];
}

public class Q783_MinDistanceBetweenBSTNodesTests : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q783_MinDistanceBetweenBSTNodesTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q783_MinDistanceBetweenBSTNodes();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.MinDiffInBST(tree!);
        Assert.Equal(expected, actual);
    }
}
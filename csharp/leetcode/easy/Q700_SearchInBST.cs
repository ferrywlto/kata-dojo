
namespace dojo.leetcode;

public class Q700_SearchInBST
{
    public TreeNode SearchBST(TreeNode root, int val) 
    {
        return new TreeNode();    
    }    
}

public class Q700_SearchInBSTTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{4, 2, 7, 1, 3}, 2, new int?[]{2, 1, 3}],
        [new int?[]{4, 2, 7, 1, 3}, 5, Array.Empty<int?>()],
    ];
}

public class Q700_SearchInBSTTests : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q700_SearchInBSTTestData))]
    public void OfficialTestCases(int?[] input, int valToFind, int?[] expected)
    {
        var sut = new Q700_SearchInBST();
        var inputTree = TreeNode.FromLevelOrderingIntArray(input);
        var actualTree = sut.SearchBST(inputTree!, valToFind);

        var expectedTree = TreeNode.FromLevelOrderingIntArray(expected);
        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}
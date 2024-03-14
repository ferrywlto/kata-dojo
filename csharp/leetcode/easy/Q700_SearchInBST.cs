namespace dojo.leetcode;

public class Q700_SearchInBST
{
    // TC: O(n)
    // SC: O(1)
    public TreeNode? SearchBST(TreeNode root, int val) 
    {
        var node = root;
        while(node != null)
        {
            if(val > node.val) node = node.right;
            else if(val < node.val) node = node.left;
            else return node;
        }
        return null;
    }
}

public class Q700_SearchInBSTTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{4, 2, 7, 1, 3}, 2, new int?[]{2, 1, 3}],
        [new int?[]{4, 2, 7, 1, 3}, 5, Array.Empty<int?>()],
        [new int?[]{18,2,22,null,null,null,63,null,84,null,null}, 63, new int?[] {63, null, 84}],
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
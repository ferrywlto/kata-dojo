
namespace dojo.leetcode;

public class Q226_InvertBinaryTree
{
    public TreeNode? InvertTree(TreeNode? root) 
    {
        return null;    
    }
}

public class Q226_InvertBinaryTreeTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{4,2,7,1,3,6,9}, new int[]{4,7,2,9,6,3,1}],
        [new int[]{2,1,3}, new int[]{2,3,1}],
        [Array.Empty<int>(), Array.Empty<int>()],
    ];
}

public class Q226_InvertBinaryTreeTests(ITestOutputHelper output): TreeNodeTests(output)
{
    [Theory]
    [ClassData(typeof(Q226_InvertBinaryTreeTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q226_InvertBinaryTree();
        var inputConverted = Array.ConvertAll<int, int?>(input, x => x);
        var expectedConverted = Array.ConvertAll<int, int?>(expected, x => x);

        var expectedTree = TreeNode.FromLevelOrderingIntArray(expectedConverted);
        var tree = TreeNode.FromLevelOrderingIntArray(inputConverted);
        var actualTree = sut.InvertTree(tree);

        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}

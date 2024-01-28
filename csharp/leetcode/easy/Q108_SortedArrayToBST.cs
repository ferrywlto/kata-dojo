
namespace dojo.leetcode;

public class Q108_SortedArrayToBST
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return new TreeNode();
    }
}

public class Q108_SortedArrayToBSTTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{-10,-3,0,5,9}, new int?[]{0,-3,9,-10,null,5}],
        [new int[]{1,3}, new int?[]{3,1}],
    ];
}

public class Q108_SortedArrayToBSTTests(ITestOutputHelper output): TreeNodeTests(output)
{
    [Theory]
    [ClassData(typeof(Q108_SortedArrayToBSTTestData))]
    public void OfficialTestCases(int[] input, int?[] expected)
    {
        var sut = new Q108_SortedArrayToBST();
        var expectedTree = TreeNode.FromLevelOrderingIntArray(expected);
        var actualTree = sut.SortedArrayToBST(input);
        AssertTreeNodeEqual(expectedTree, actualTree);
    }
}
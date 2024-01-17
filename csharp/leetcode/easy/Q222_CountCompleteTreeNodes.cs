
namespace dojo.leetcode;

public class Q222_CountCompleteTreeNodes
{
    public int CountNodes(TreeNode? root) 
    {
        return 0;
    }
}

public class Q222_CountCompleteTreeNodesTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{1,2,3,4,5,6}, 6],
        [Array.Empty<int>(), 0],
        [new int[]{1}, 1],
    ];
}

public class Q222_CountCompleteTreeNodesTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q222_CountCompleteTreeNodesTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var sut = new Q222_CountCompleteTreeNodes();
        var actual = sut.CountNodes(tree);
        Assert.Equal(expected, actual);
    }
}

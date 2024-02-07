
namespace dojo.leetcode;

public class Q404_SumOfLeftLeaves
{
    public int SumOfLeftLeaves(TreeNode? root)
    {
        return 0;
    }
}

public class Q404_SumOfLeftLeavesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{3,9,20,null,null,15,7},24],
        [new int?[]{1},0],
    ];
}

public class Q404_SumOfLeftLeavesTests
{
    [Theory]
    [ClassData(typeof(Q404_SumOfLeftLeavesTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q404_SumOfLeftLeaves();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.SumOfLeftLeaves(tree);
        Assert.Equal(expected, actual);
    }
}

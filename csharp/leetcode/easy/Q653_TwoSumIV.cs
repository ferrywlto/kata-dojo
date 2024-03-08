
namespace dojo.leetcode;

public class Q653_TwoSumIV
{
    public bool FindTarget(TreeNode root, int k) 
    {
        return false;    
    }
}

public class Q653_TwoSumIVTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[] {5,3,6,2,4,null,7}, 9, true],
        [new int?[] {5,3,6,2,4,null,7}, 28, false],
    ];
}

public class Q653_TwoSumIVTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q653_TwoSumIVTestData))]
    public void OfficialTestCases(int?[] input, int k, bool expected)
    {
        var sut = new Q653_TwoSumIV();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.FindTarget(tree!, k);
        Assert.Equal(expected, actual);
    }
}
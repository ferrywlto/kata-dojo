
namespace dojo.leetcode;

public class Q110_CheckTreeHeightBalanced
{
    public bool IsBalanced(TreeNode root) 
    {
        return false;    
    }
}

public class Q110_CheckTreeHeightBalancedTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[] {3,9,20,null,null,15,7}, true],
        [new int?[] {1,2,2,3,3,null,null,4,4}, false],
        [Array.Empty<int?>(), true],
    ];
}

public class Q110_CheckTreeHeightBalancedTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q110_CheckTreeHeightBalancedTestData))]
    public void OfficialTestCases(int?[] input, bool expected)
    {
        var sut = new Q110_CheckTreeHeightBalanced();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.IsBalanced(tree!);
        Assert.Equal(expected, actual);
    }
}
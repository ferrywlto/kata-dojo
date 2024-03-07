
namespace dojo.leetcode;

public class Q637_AvgOfLevelsInBinaryTree
{
    public IList<double> AverageOfLevels(TreeNode root) 
    {
        return [];    
    }
}

public class Q637_AvgOfLevelsInBinaryTreeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{3,9,20,null,null,15,7}, new double[]{3.00000,14.50000,11.00000}],
        [new int?[]{3,9,20,15,7}, new double[]{3.00000,14.50000,11.00000}],
    ];
}

public class Q637_AvgOfLevelsInBinaryTreeTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q637_AvgOfLevelsInBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, double[] expected)
    {
        var sut = new Q637_AvgOfLevelsInBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.AverageOfLevels(tree!);

        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}

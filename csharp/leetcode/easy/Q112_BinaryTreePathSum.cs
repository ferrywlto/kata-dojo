namespace dojo.leetcode;

public class Q112_BinaryTreePathSumTestData :LeetCodeTestData 
{
    protected override List<object[]> Data() =>
    [
        [new int?[]{5,4,8,11,null,13,4,7,2,null,null,null,1}, 22, true],
        [new int?[]{1,2,3}, 5, false],
        [Array.Empty<int?>(), 0, false],
    
    ];
}
public class Q112_BinaryTreePathSumTests 
{
    [Theory]
    [ClassData(typeof(Q112_BinaryTreePathSumTestData))]
    public void OfficialTestCases(int?[] input, int targetSum, bool expected)
    {
        var sut = new Q112_BinaryTreePathSum();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        Assert.Equal(expected, sut.HasPathSum(tree!, targetSum));
    }
}

public class Q112_BinaryTreePathSum 
{
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        return false;    
    } 
}
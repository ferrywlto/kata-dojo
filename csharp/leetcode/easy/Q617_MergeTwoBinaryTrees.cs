
namespace dojo.leetcode;

public class Q617_MergeTwoBinaryTrees
{
    public TreeNode MergeTrees(TreeNode? root1, TreeNode? root2) 
    {
        return new TreeNode();    
    }
}

public class Q617_MergeTwoBinaryTreesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{1,3,2,5}, new int?[]{2,1,3,null,4,null,7}, new int?[]{3,4,5,5,4,null,7}],
        [new int?[]{1}, new int?[]{1,2}, new int?[]{2,2}],
    ];
}

public class Q617_MergeTwoBinaryTreesTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q617_MergeTwoBinaryTreesTestData))]
    public void OfficialTestCases(int?[] input1, int?[] input2, int?[] expected)
    {
        var sut = new Q617_MergeTwoBinaryTrees();
        var tree1 = TreeNode.FromLevelOrderingIntArray(input1);
        var tree2 = TreeNode.FromLevelOrderingIntArray(input2);
        var treeExpected = TreeNode.FromLevelOrderingIntArray(expected);
        var treeActual = sut.MergeTrees(tree1, tree2);

        AssertTreeNodeEqual_Loop(treeExpected!, treeActual);
    }
}
namespace dojo.leetcode;

public class Q872_LeafSimilarTrees
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2) 
    {
        return false;    
    }
}

public class Q872_LeafSimilarTreesTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int?[]{3,5,1,6,2,9,8,null,null,7,4},
            new int?[]{3,5,1,6,7,4,2,null,null,null,null,null,null,9,8},
            true,
        ],
        [
            new int?[]{1,2,3},
            new int?[]{1,3,2},
            false,
        ]
    ];
}

public class Q872_LeafSimilarTreesTests
{
    [Theory]
    [ClassData(typeof(Q872_LeafSimilarTreesTestData))]
    public void OfficialTestCases(int?[] input1, int?[] input2, bool expected)
    {
        var sut = new Q872_LeafSimilarTrees();
        var tree1 = TreeNode.FromLevelOrderingIntArray(input1);
        var tree2 = TreeNode.FromLevelOrderingIntArray(input2);
        var actual = sut.LeafSimilar(tree1!, tree2!);
        Assert.Equal(expected, actual);
    }
}
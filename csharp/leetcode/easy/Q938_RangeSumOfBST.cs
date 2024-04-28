class Q938_RangeSumOfBST
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        return 0;
    }
}

class Q938_RangeSumOfBSTTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{10,5,15,3,7,null,18}, 7, 15, 32],
        [new int?[]{10,5,15,3,7,13,18,1,null,6}, 6, 10, 23],
    ];
}

public class Q938_RangeSumOfBSTTests : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q938_RangeSumOfBSTTestData))]
    public void OfficialTestCases(int?[] input, int low, int high, int expected)
    {
        var sut = new Q938_RangeSumOfBST();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.RangeSumBST(tree!, low, high);
        Assert.Equal(expected, actual);
    }
}
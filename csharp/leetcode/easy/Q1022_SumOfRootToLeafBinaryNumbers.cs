class Q1022_SumOfRootToLeafBinaryNumbers
{

    public int SumRootToLeaf(TreeNode root)
    {
        return 0;
    }

}

class Q1022_SumOfRootToLeafBinaryNumbersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{1,0,1,0,1,0,1}, 22],
        [new int?[]{0}, 0],
    ];
}

public class Q1022_SumOfRootToLeafBinaryNumbersTests(ITestOutputHelper output) : TreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q1022_SumOfRootToLeafBinaryNumbersTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q1022_SumOfRootToLeafBinaryNumbers();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        DebugTree(tree!);
        var actual = sut.SumRootToLeaf(tree!);
        Assert.Equal(expected, actual);
    }
}
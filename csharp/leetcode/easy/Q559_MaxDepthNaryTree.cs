
using System.Runtime.CompilerServices;

namespace dojo.leetcode;

public class Q559_MaxDepthNaryTree
{
    public int MaxDepth(NaryTreeNode root) 
    {
        // use depth first search
        // update max depth whenever stack.count > max depth when push
        return 0;
    }
}

public class Q559_MaxDepthNaryTreeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        // [new int?[]{1,null,3,2,4,null,5,6}, 3],
        [new int?[]{1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14}, 5],
    ];
}

public class Q559_MaxDepthNaryTreeTests : NaryTreeTest
{
    public Q559_MaxDepthNaryTreeTests(ITestOutputHelper output) : base(output) {}

    [Theory]
    [ClassData(typeof(Q559_MaxDepthNaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q559_MaxDepthNaryTree();
        var tree = NaryTreeNode.FromLevelOrderIntArray(input);
        DebugTree(tree!);
        var actual = sut.MaxDepth(tree!);
        Assert.Equal(expected, actual);
    }
}

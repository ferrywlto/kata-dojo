
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace dojo.leetcode;

public class Q559_MaxDepthNaryTree
{
    // TC: O(n)
    // SC: O(n)
    public int MaxDepth(NaryTreeNode root) 
    {
        if (root == null) return 0;
        if (root.children.Count == 0) return 1;

        var maxDepth = 1;
        var stack = new Stack<(NaryTreeNode node, int depth)>();
        stack.Push((root, 1));
        while(stack.Count > 0)
        {
            var (node, depth) = stack.Pop();
            if (depth > maxDepth) 
                maxDepth = depth;

            if(node.children.Count > 0)
            {
                for(var i=0; i<node.children.Count; i++)
                {
                    stack.Push((node.children[i], depth + 1));
                }
            }
        }
        return maxDepth;
    }
}

public class Q559_MaxDepthNaryTreeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{1,null,3,2,4,null,5,6}, 3],
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

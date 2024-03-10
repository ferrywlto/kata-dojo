
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
        var tree = FromLevelOrderIntArray(input, true);
        var actual = sut.MaxDepth(tree!);
        Assert.Equal(expected, actual);
    }
}


public class NaryTreeNode {
    public int val;
    public IList<NaryTreeNode>? children;

    public NaryTreeNode() {}

    public NaryTreeNode(int _val) {
        val = _val;
    }

    public NaryTreeNode(int _val, IList<NaryTreeNode> _children) {
        val = _val;
        children = _children;
    }
}

public abstract class NaryTreeTest : BaseTest
{
    public NaryTreeTest(ITestOutputHelper output) : base(output) {}
    protected NaryTreeNode? FromLevelOrderIntArray(int?[] input, bool debug = false)
    {
        if (input.Length == 0) return null;

        var root = new NaryTreeNode(input[0] ?? int.MinValue);
        var queue = new Queue<NaryTreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while(i < input.Length && queue.Count > 0)
        {
            var parent = queue.Dequeue();

            if(input[i] == null)
            {
                i++;
                var childList = new List<NaryTreeNode>();
                while(i < input.Length && input[i] != null)
                {
                    var childNode = new NaryTreeNode(input[i] ?? int.MinValue);
                    childList.Add(childNode);
                    queue.Enqueue(childNode);
                    i++;
                }
                parent.children = childList;
            }
        }
        if(debug)
        {
            var debugQueue = new Queue<NaryTreeNode>();
            debugQueue.Enqueue(root);
            while(debugQueue.Count > 0)
            {
                var debugNode = debugQueue.Dequeue();   
                string childStr = (debugNode.children == null || debugNode.children.Count == 0)
                    ? "No child"
                    : string.Join(',', debugNode.children.Select(x => x.val));
                Output!.WriteLine($"current node:{debugNode.val}, children: {childStr}, count: {debugNode.children!.Count}");

                for(var j=0; i<debugNode.children.Count; j++)
                {
                    Output!.WriteLine($"current node:{debugNode.children[j].val}");
                    debugQueue.Enqueue(debugNode.children[j]);
                }
            }
        }

        return root;
    }
}
namespace dojo.leetcode;

/*
// Definition for a Node.
*/
public class Node {
    public int val;
    public IList<Node>? children;

    public Node(int?[] nums) {}

    public Node(int _val) {
        val = _val;
    }
    // use depth first search
    // update max depth whenever stack.count > max depth when push
    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}

// need to implement the N-ary tree Node class 
public class Q559_MaximumDepthOfNaryTree
{
    public int MaxDepth(Node root)
    {
        return 0;
    }
}

public class Q559_MaximumDepthOfNaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {1, null, 3, 2, 4, null, 5, 6}, 3],
        [new int?[] {1, null, 2, 3, 4, 5, null, null, 6, 7, null, 8, null, 9, 10, null, null, 11, null, 12, null, 13, null, null, 14}, 5],
    ];
}

public class Q559_MaximumDepthOfNaryTreeTests
{
    [Theory]
    [ClassData(typeof(Q559_MaximumDepthOfNaryTreeTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q559_MaximumDepthOfNaryTree();
        var tree = new Node(input);
        var actual = sut.MaxDepth(tree!);
        Assert.Equal(expected, actual);
    }
}
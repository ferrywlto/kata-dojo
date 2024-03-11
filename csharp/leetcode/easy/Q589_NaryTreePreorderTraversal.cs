
namespace dojo.leetcode;

public class Q589_NaryTreePreorderTraversal
{
    // TC: O(n)
    // SC: O(n)
    public IList<int> Preorder(NaryTreeNode root) 
    {
        if (root == null) return [];

        var result = new List<int>();
        var stack = new Stack<NaryTreeNode>();
        stack.Push(root);

        NaryTreeNode? node;
        while (stack.Count > 0)
        {
            node = stack.Pop();
            result.Add(node.val);

            for(var i=node.children.Count-1; i>=0; i--)
            {
                if(node.children[i] != null)
                {
                    stack.Push(node.children[i]);
                }
            }
        }

        return result;
    }
}

public class Q589_NaryTreePreorderTraversalTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int?[]{1, null, 3, 2, 4, null, 5, 6}, 
            new int[] {1,3,5,6,2,4}
            ],
        [
            new int?[]{1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14}, 
            new int[] {1,2,3,6,7,11,14,4,8,12,5,9,13,10}
        ],
    ];
}

public class Q589_NaryTreePreorderTraversalTests(ITestOutputHelper output) : NaryTreeNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q589_NaryTreePreorderTraversalTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q589_NaryTreePreorderTraversal();
        var tree = NaryTreeNode.FromLevelOrderIntArray(input);
        DebugTree(tree!);
        var actual = sut.Preorder(tree!);

        Output!.WriteLine($"expected: {string.Join(',', expected)}");
        Output!.WriteLine($"actual: {string.Join(',', actual)}");
        Assert.Equal(expected, actual);
    }
}

namespace dojo.leetcode;

public class Q590_NaryTreePostorderTraversal
{
    List<int> result = [];
    public IList<int> Postorder(NaryTreeNode root) 
    {
        Traverse(root);
        return result;    
    }
    public void Traverse(NaryTreeNode node)
    {
        if (node != null)
        {
            for(var i=0; i<node.children.Count; i++)
            {
                Postorder(node.children[i]);
            }
            result.Add(node.val);
        }
    }
}

public class Q590_NaryTreePostorderTraversalTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int?[]{1,null,3,2,4,null,5,6}, 
            new int[]{5,6,3,2,4,1}
        ],
        [
            new int?[]{1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14}, 
            new int[]{2,6,14,11,7,3,12,8,4,13,9,10,5,1}
        ],
    ];
}

public class Q590_NaryTreePostorderTraversalTest : NaryTreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q590_NaryTreePostorderTraversalTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q590_NaryTreePostorderTraversal();
        var tree = NaryTreeNode.FromLevelOrderIntArray(input);
        var actual = sut.Postorder(tree!);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
// TC: O(n), all nodes need to traverse once
// SC: O(tree1.depth + tree2.depth)
class Q872_LeafSimilarTrees
{
    readonly Stack<TreeNode> ParallelStack1 = new();
    readonly Stack<TreeNode> ParallelStack2 = new();
    int? Leaf1Value = null;
    int? Leaf2Value = null;
    public bool LeafSimilar(TreeNode root1, TreeNode root2) 
    {
        ParallelStack1.Push(root1);
        ParallelStack2.Push(root2);
        
        while(ParallelStack1.Count > 0 || ParallelStack2.Count > 0)
        {
            Leaf1Value = GetNextLeaf(ParallelStack1);
            Leaf2Value = GetNextLeaf(ParallelStack2);
            if (Leaf1Value != Leaf2Value) return false;
        }
        return true;
    }

    public int? GetNextLeaf(Stack<TreeNode> stack)
    {
        while(stack.Count > 0)
        {
            var node = stack.Pop();
            if(node.IsLeaf)
            {
                return node.val;
            }
            else 
            {
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
        }
        return null;
    }
}

class Q872_LeafSimilarTreesTestData : TestData
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
        ],
        [
            new int?[]{4,2,6,1,3,5,7},
            new int?[]{4,2,6,null,3,5,7},
            false,
        ],
        [
            new int?[]{3,5,1,6,7,4,2,null,null,null,null,null,null,9,11,null,null,8,10},
            new int?[]{3,5,1,6,2,9,8,null,null,7,4},
            false,
        ],
    ];
}

public class Q872_LeafSimilarTreesTests(ITestOutputHelper output) : TreeNodeTest(output)
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
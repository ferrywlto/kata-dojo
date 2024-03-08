
namespace dojo.leetcode;

public class Q671_SecondMinNodeInBinaryTree
{
    // TC: O(n)
    // SC: O(n)
    public int FindSecondMinimumValue(TreeNode root) 
    {
        // minimum is always at root in this question
        // all nodes have either 2 or 0 child in this question
        // go down to smaller route only, the larger one is second minimum candidate
        long secMin = long.MaxValue;
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while(stack.Count > 0)
        {
            var node = stack.Pop();
            if (node.left?.val > node.right?.val)
            {
                if (node.left?.val < secMin)
                {
                    secMin = node.left.val;
                    stack.Push(node.right);
                }
            }
            else if (node.left?.val < node.right?.val)
            {
                if (node.right?.val < secMin)
                {
                    secMin = node.right.val;
                    stack.Push(node.left);
                }
            }
            else if(node.left != null && node.right != null)
            {
                stack.Push(node.left);
                stack.Push(node.right);
            }
        }
        return secMin == long.MaxValue ? -1 : (int)secMin;    
    }
}

public class Q671_SecondMinNodeInBinaryTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[] {2,2,2147483647}, 2147483647],
        [new int?[] {1,1,3,1,1,3,4,3,1,1,1,3,8,4,8,3,3,1,6,2,1}, 2],
        [new int?[] {2,2,5,null,null,5,7}, 5],
        [new int?[] {1,1,2,1,1,2,2}, 2],
        [new int?[] {2,2,2}, -1],
        [new int?[] {2}, -1],
    ];
}

public class Q671_SecondMinNodeInBinaryTreeTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q671_SecondMinNodeInBinaryTreeTestData))]
    public void OfficicalTestCases(int?[] input, int expected)
    {
        var sut = new Q671_SecondMinNodeInBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.FindSecondMinimumValue(tree!);
        Assert.Equal(expected, actual);
    }
}
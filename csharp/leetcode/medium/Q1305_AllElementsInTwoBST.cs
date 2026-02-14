
public class Q1305_AllElementsInTwoBST(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n + m) where n and m are the number of nodes in the two BSTs
    // SC: O(n + m) for the result list
    // The function returns a sorted list of all elements from both BSTs.
    // It uses in-order traversal to collect elements from both trees and merges them.
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        var result = new List<int>();

        InorderTraversal_Recursion(root1, list1);

        InorderTraversal_Recursion(root2, list2);

        var list1Idx = 0;
        var list2Idx = 0;

        while (list1Idx < list1.Count || list2Idx < list2.Count)
        {
            if (list1Idx == list1.Count && list2Idx < list2.Count)
            {
                result.Add(list2[list2Idx++]);
                continue;
            }

            if (list2Idx == list2.Count && list1Idx < list1.Count)
            {
                result.Add(list1[list1Idx++]);
                continue;
            }

            if (list1[list1Idx] < list2[list2Idx])
            {
                result.Add(list1[list1Idx++]);
            }
            else
            {
                result.Add(list2[list2Idx++]);
            }
        }

        return result;
    }

    private void InorderTraversal_Recursion(TreeNode? node, IList<int> result)
    {
        if (node != null)
        {
            InorderTraversal_Recursion(node.left, result);
            result.Add(node.val);
            InorderTraversal_Recursion(node.right, result);
        }
    }

    public static TheoryData<TreeNode, TreeNode, IList<int>> TestData => new()
    {
        {
            TreeNode.FromLevelOrderingIntArray([2,1,4])!,
            TreeNode.FromLevelOrderingIntArray([1,0,3])!,
            [0, 1, 1, 2, 3, 4]
        },
        {
            TreeNode.FromLevelOrderingIntArray([1,null,8])!,
            TreeNode.FromLevelOrderingIntArray([8,1])!,
            [1, 1, 8, 8]
        },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode root1, TreeNode root2, IList<int> expected)
    {
        var actual = GetAllElements(root1, root2);
        Assert.Equal(expected, actual);
    }
}

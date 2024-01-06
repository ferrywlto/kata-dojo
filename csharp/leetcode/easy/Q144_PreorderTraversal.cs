using dojo.leetcode;

public class Q144_PreorderTraversalTestData :LeetCodeTestData
 {
    protected override List<object[]> Data() => 
    [
        [new int?[] { 2,3,null,1 }, new int[] { 2,3,1 }],
        [new int?[] { 1, null, 2, 3 }, new int[] { 1, 2, 3 }],
        [new int?[] { 1 }, new int[] { 1 }],
        [Array.Empty<int?>(), Array.Empty<int>()],
    ];
    
}
public class Q144_PreorderTraversalTests : TreeNodeTests
{
    [Theory]
    [ClassData(typeof(Q144_PreorderTraversalTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q144_PreorderTraversal();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.PreorderTraversal(tree);
         
        Console.WriteLine($"expected: {string.Join(',', expected)}");
        Console.WriteLine($"actual: {string.Join(',', actual.ToArray())}");
        Assert.True(Enumerable.SequenceEqual(expected, actual.ToArray()));
    }
 }
public class Q144_PreorderTraversal 
{
    public IList<int> PreorderTraversal(TreeNode? root) {
        if (root == null) return new List<int>();
        var result = new List<int>();
        PreorderTraversal_Recursion(root, result);
        return result;
    }

    public void PreorderTraversal_Recursion(TreeNode? node, List<int> result)
    {
        if (node == null) return;
        result.Add(node.val);
        PreorderTraversal_Recursion(node.left, result);
        PreorderTraversal_Recursion(node.right, result);
    }

    // TC: O(num_nodes), SC: O(height_of_tree)
    public IList<int> PreorderTraversal_Iteration(TreeNode? root) 
    {
        if (root == null) return new List<int>();
        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        TreeNode? node;
        while (queue.Count > 0) 
        {
            node = queue.Dequeue();
            result.Add(node.val);
            Console.WriteLine($"node.val: {node.val}");
            var current = node;
            while (current.left != null)
            {                
                queue.Enqueue(current.left);
                current = current.left;
            }
            while (current.right != null) 
            {
                queue.Enqueue(current.right);
                current = current.right;
            }
        }

        return result;
    }
 }

namespace dojo.leetcode;

public class Q637_AvgOfLevelsInBinaryTree
{
    // TC: O(n)
    // SC: O(n)
    public IList<double> AverageOfLevels(TreeNode? root) 
    {
        if (root == null) return [0];
        
        List<double> result = [];

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            double levelSum = 0;
            var levelCount = queue.Count;
            for(var i=0; i<levelCount; i++)
            {
                var node = queue.Dequeue();
                levelSum += node.val;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            result.Add(levelSum / levelCount);
        }
        return result;
    }
}

public class Q637_AvgOfLevelsInBinaryTreeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{3,9,20,null,null,15,7}, new double[]{3.00000,14.50000,11.00000}],
        [new int?[]{3,9,20,15,7}, new double[]{3.00000,14.50000,11.00000}],
    ];
}

public class Q637_AvgOfLevelsInBinaryTreeTests : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q637_AvgOfLevelsInBinaryTreeTestData))]
    public void OfficialTestCases(int?[] input, double[] expected)
    {
        var sut = new Q637_AvgOfLevelsInBinaryTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.AverageOfLevels(tree!);

        Console.WriteLine($"actual: {string.Join(',', actual)}");
        Assert.Equal(expected, actual);
    }
}

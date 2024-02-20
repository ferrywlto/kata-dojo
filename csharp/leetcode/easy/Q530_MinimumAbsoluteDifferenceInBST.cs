namespace dojo.leetcode;

public class Q530_MinimumAbsoluteDifferenceInBST
{
    public int GetMinimumDifference(TreeNode root)
    {
        if (root.IsLeaf) return 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var hashset = new HashSet<int>();

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            hashset.Add(node.val);

            if (node.left != null)
                queue.Enqueue(node.left);

            if (node.right != null)
                queue.Enqueue(node.right);
        }

        var temp = hashset.ToArray();
        Array.Sort(temp);

        var smallest = int.MaxValue;
        for(var i=0; i<temp.Length - 1; i++)
        {
            var diff = Math.Abs(temp[i] - temp[i + 1]);
            if (diff < smallest)
                smallest = diff;
        }

        return smallest;
    }
}

public class Q530_MinimumAbsoluteDifferenceInBSTTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{1,0,48,null,null,12,49}, 1],
        [new int?[]{4,2,6,1,3}, 1],
        [new int?[]{236,104,701,null,227,null,911}, 9],
    ];
}

public class Q530_MinimumAbsoluteDifferenceInBSTTests
{
    [Theory]
    [ClassData(typeof(Q530_MinimumAbsoluteDifferenceInBSTTestData))]
    public void OfficialTestCases(int?[] input, int expected)
    {
        var sut = new Q530_MinimumAbsoluteDifferenceInBST();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.GetMinimumDifference(tree!);
        Assert.Equal(expected, actual);
    }
}
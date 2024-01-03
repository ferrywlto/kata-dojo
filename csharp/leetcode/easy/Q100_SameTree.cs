namespace dojo.leetcode;

public class Q100_SameTreeTestData : LeetCodeTestData
{
    protected override List<object[]> Data() =>
    [
        [new int?[]{1, 2, 3}, new int?[]{1, 2, 3}, true],
        [new int?[]{1, 2}, new int?[]{1, null, 2}, false],
        [new int?[]{1 ,2, 1}, new int?[]{1, 1, 2}, false],
        [new int?[]{1 }, new int?[]{1, null, 2}, false],
    ];
}

public class Q100_SameTreeTests : TreeNodeTests 
{ 
    [Theory]
    [ClassData(typeof(Q100_SameTreeTestData))]
    public void OfficialTestCases(int?[] p, int?[] q, bool expected) 
    {
        var sut = new Q100_SameTree();
        var pTree = TreeNode.FromLevelOrderingIntArray(p);
        var qTree = TreeNode.FromLevelOrderingIntArray(q);
        var actual = sut.IsSameTree(pTree, qTree);
        Assert.Equal(expected, actual);
    }
}
public class Q100_SameTree
{
    // This one can solve from the utility class created for previous tree questions, just need some tweak from Assert to return boolean.
    // TC: O(nodes_larger_tree) -> O(n), SC: O(max_width_tree1 + max_width_tree2) -> O(n)
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        var p_queue = new Queue<TreeNode?>();
        var q_queue = new Queue<TreeNode?>();

        p_queue.Enqueue(p);
        q_queue.Enqueue(q);

        while(p_queue.Count > 0 && q_queue.Count > 0) {
            // early termination if structure is not the same (i.e. one tree has subtee while the other doesn't)
            if (p_queue.Count != q_queue.Count) return false;

            var p_current = p_queue.Dequeue();
            var q_current = q_queue.Dequeue();

            if (p_current == null && q_current == null) continue;

            if (p_current?.val != q_current?.val) return false;

            p_queue.Enqueue(p_current?.left);
            p_queue.Enqueue(p_current?.right);

            q_queue.Enqueue(q_current?.left);
            q_queue.Enqueue(q_current?.right);
        }
        return true;
    }
}
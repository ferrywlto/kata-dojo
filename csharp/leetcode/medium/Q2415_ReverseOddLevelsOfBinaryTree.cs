public class Q2415_ReverseOddLevelOfBinaryTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n), n scale with number of nodes in tree
    // SC: O(d+n), d scale with depth of tree

    // This is the optimum solution but only works in perfect binary tree.
    public TreeNode ReverseOddLevels4(TreeNode root)
    {
        if (root.left == null && root.right == null) return root;
        Traverse(root.left!, root.right!, 1);
        return root;
    }
    // private void Transverse(TreeNode left, TreeNode right)
    private void Traverse(TreeNode a, TreeNode b, int depth)
    {
        if (depth % 2 == 1)
        {
            (b.val, a.val) = (a.val, b.val);
        }

        if (a.left == null) return;

        Traverse(a.left, b.right!, depth + 1);
        Traverse(a.right!, b.left!, depth + 1);
    }

    // This use array reverse but seems even slower
    public TreeNode ReverseOddLevels2(TreeNode root)
    {
        var list = new List<int?>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var node = q.Dequeue();

            list.Add(node.val);
            if (node.left != null)
                q.Enqueue(node.left);
            if (node.right != null)
                q.Enqueue(node.right);
        }

        var x = list.ToArray();
        var power = Math.Log2(x.Length);

        for (var i = 0; i <= power; i++)
        {
            var idx = (int)Math.Pow(2, i);
            if (i % 2 == 1)
                Array.Reverse(x, idx - 1, idx);
        }
        return TreeNode.FromLevelOrderingIntArray(x)!;
    }

    Dictionary<int, Stack<int>> OddLevels = new();
    public TreeNode ReverseOddLevels3(TreeNode root)
    {
        var curr = root;
        var stack = new Stack<(int, TreeNode)>();
        var level = 0;
        stack.Push((level, curr));

        while (stack.Count > 0)
        {
            var (lv, node) = stack.Pop();
            if (lv % 2 == 0 && node.left != null && node.right != null)
            {
                (node.right.val, node.left.val) = (node.left.val, node.right.val);
            }

            if (node.right != null)
            {
                stack.Push((lv + 1, node.right));
            }
            if (node.left != null)
            {
                stack.Push((lv + 1, node.left));
            }
        }

        return root;
    }
    public TreeNode ReverseOddLevels(TreeNode root)
    {
        var curr = root;
        var stack = new Stack<(int, TreeNode)>();
        var level = 0;
        stack.Push((level, curr));

        while (stack.Count > 0)
        {
            var (lv, node) = stack.Pop();
            if (lv % 2 == 1)
            {
                if (!OddLevels.TryGetValue(lv, out var levelStack))
                {
                    var stk = new Stack<int>();
                    stk.Push(node.val);
                    OddLevels.Add(lv, stk);
                }
                else
                {
                    levelStack.Push(node.val);
                }
            }
            lv++;
            if (node.right != null)
            {
                stack.Push((lv, node.right));
            }
            if (node.left != null)
            {
                stack.Push((lv, node.left));
            }
        }
        level = 0;
        stack.Push((level, curr));
        while (stack.Count > 0)
        {
            var (lv, node) = stack.Pop();
            if (lv % 2 == 1)
            {
                node.val = OddLevels[lv].Pop();
            }
            lv++;
            if (node.right != null)
            {
                stack.Push((lv, node.right));
            }
            if (node.left != null)
            {
                stack.Push((lv, node.left));
            }
        }
        return root;
    }
    public static TheoryData<TreeNode, TreeNode> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([2,3,5,8,13,21,34])!, TreeNode.FromLevelOrderingIntArray([2,5,3,8,13,21,34])!},
        {TreeNode.FromLevelOrderingIntArray([7,13,11])!, TreeNode.FromLevelOrderingIntArray([7,11,13])!},
        {TreeNode.FromLevelOrderingIntArray([0,1,2,0,0,0,0,1,1,1,1,2,2,2,2])!, TreeNode.FromLevelOrderingIntArray([0,2,1,0,0,0,0,2,2,2,2,1,1,1,1])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode input, TreeNode expected)
    {
        var actual = ReverseOddLevels4(input);
        DebugTree(actual);
        AssertTreeNodeEqual(actual, expected);
    }
}

public class Q2415_ReverseOddLevelOfBinaryTree(ITestOutputHelper output) : TreeNodeTest(output)
{
    Dictionary<int, Stack<int>> OddLevels = new();
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
        var actual = ReverseOddLevels(input);
        AssertTreeNodeEqual(actual, expected);
    }
}

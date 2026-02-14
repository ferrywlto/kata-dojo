
public class Q2196_CreateBinaryTreeFromDescription(ITestOutputHelper output) : TreeNodeTest(output)
{
    // TC: O(n + d), n scale with length of descriptions, d scale with depth of result tree
    // SC: O(n)
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var parents = new Dictionary<int, TreeNode>();
        var nodes = new Dictionary<int, TreeNode>();
        TreeNode? head = null;

        foreach (var r in descriptions)
        {
            var parent = r[0];
            var child = r[1];
            var isLeft = r[2] == 1;

            if (!nodes.TryGetValue(parent, out var parentNode))
            {
                parentNode = new TreeNode(parent);
                nodes.Add(parent, parentNode);
            }

            if (!nodes.TryGetValue(child, out var childNode))
            {
                childNode = new TreeNode(child);
                nodes.Add(child, childNode);
            }

            if (isLeft)
            {
                parentNode.left = childNode;
            }
            else
            {
                parentNode.right = childNode;
            }

            parents.Add(child, parentNode);
            head = parentNode;
        }

        while (parents.ContainsKey(head!.val))
        {
            head = parents[head.val];
        }
        return head!;
    }
    public static TheoryData<int[][], TreeNode> TestData => new()
    {
        {[[20,15,1],[20,17,0],[50,20,1],[50,80,0],[80,19,1]], TreeNode.FromLevelOrderingIntArray([50,20,80,15,17,19])!},
        {[[1,2,1],[2,3,0],[3,4,1]], TreeNode.FromLevelOrderingIntArray([1,2,null,null,3,4])!},
        {[[85,82,1],[74,85,1],[39,70,0],[82,38,1],[74,39,0],[39,13,1]], TreeNode.FromLevelOrderingIntArray([74,85,39,82,null,13,70,38])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, TreeNode expected)
    {
        var actual = CreateBinaryTree(input);
        AssertTreeNodeEqual(expected, actual);
    }
}

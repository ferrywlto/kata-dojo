
public class Q894_AllPossibleFullBinaryTree : TreeNodeTest
{
    public Q894_AllPossibleFullBinaryTree(ITestOutputHelper output) : base(output)
    {
    }

    public IList<TreeNode> AllPossibleFBT(int n)
    {
        var result = new List<TreeNode>();
        if (n == 1)
        {
            result.Add(new TreeNode(0));
            return result;
        }
        else if (n == 3)
        {
            result.Add(new TreeNode(0, new TreeNode(0), new TreeNode(0)));
            return result;
        }

        // it must be n - 2 possibilities
        var len = n - 2;
        for (var i = 0; i < len; i++)
        {
            result.Add(ConstructTree(i));
        }
        return result;
    }
    private TreeNode DefaultRoot()
    {
        return new TreeNode(0, new TreeNode(0), new TreeNode(0));
    }
    // 4 choices
    // 00
    // 01
    // 10
    // 11
    private TreeNode ConstructTree(int option)
    {
        // var 
        while (option > 0)
        {
            // if()
            option >>= 1;
        }
        return new TreeNode();
    }

    public static TheoryData<int, IList<TreeNode>> TestData => new()
    {
        {7,  new List<TreeNode> {
            TreeNode.FromLevelOrderingIntArray([0,0,0,null,null,0,0,null,null,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,null,null,0,0,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,0,0,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,0,0,null,null,null,null,0,0])!,
            TreeNode.FromLevelOrderingIntArray([0,0,0,0,0,null,null,0,0])!
        }},
        {3, new List<TreeNode> {
            TreeNode.FromLevelOrderingIntArray([0,0,0])!
        }}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, IList<TreeNode> expected)
    {
        var actual = AllPossibleFBT(input);
        for (var i = 0; i < actual.Count; i++)
        {
            AssertTreeNodeEqual(expected[i], actual[i]);
        }
    }
}


namespace dojo.leetcode;

public class Q257_BinaryTreePaths
{
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();

        return [];
    }

    public void PrintPath(TreeNode node, int[] path, List<string> result) 
    {
        if(node != null)
        {
            if (node.IsLeaf) 
            {
                result.Add($"{string.Join("->", path)}->{node.val}");
                return;
            }
            if (node.left != null) 
            {
                PrintPath(node.left, [.. path, .. new int[] { node.val }], result);
            }
            if (node.right != null)
            {
                PrintPath(node.right, [.. path, .. new int[] { node.val }], result);
            }
        }
    }
}

public class Q257_BinaryTreePathsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int?[]{1,2,3,null,5}, new string[]{"1->2->5","1->3"}],
        [new int?[]{1}, new string[]{"1"}],
    ];
}


public class Q257_BinaryTreePathsTests(ITestOutputHelper output):TreeNodeTests(output)
{
    [Theory]
    [ClassData(typeof(Q257_BinaryTreePathsTestData))]
    public void OfficialTestCases(int?[] input, string[] expected)
    {
        var sut = new Q257_BinaryTreePaths();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.BinaryTreePaths(tree!);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
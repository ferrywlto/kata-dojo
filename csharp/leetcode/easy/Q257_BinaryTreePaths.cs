
namespace dojo.leetcode;

public class Q257_BinaryTreePaths
{
    public IList<string> BinaryTreePaths(TreeNode? root)
    {
        if (root == null) return [];
        if (root.IsLeaf) return [root.val.ToString()];

        var result = new List<string>();
        PrintPath(root, [], result);
        return result;
    }

    public void PrintPath(TreeNode? node, List<int> path, List<string> result) 
    {
        if (node == null) return;

        path.Add(node.val);
        if (node.IsLeaf) 
        {
            result.Add(string.Join("->", path));
        }
        else 
        {
            PrintPath(node.left, path, result);
            PrintPath(node.right, path, result);
        }

        path.RemoveAt(path.Count - 1);
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
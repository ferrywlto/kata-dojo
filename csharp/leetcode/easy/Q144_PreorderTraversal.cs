using dojo.leetcode;

public class Q144_PreorderTraversalTestData :LeetCodeTestData
 {
    protected override List<object[]> Data() => 
    [
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

        Assert.True(Enumerable.SequenceEqual(expected, actual.ToArray()));
    }
 }
public class Q144_PreorderTraversal 
{
    public IList<int> PreorderTraversal(TreeNode? root) 
    {
        return new List<int>();
    }
 }
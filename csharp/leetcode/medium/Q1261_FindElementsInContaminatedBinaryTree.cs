public class FindElements
{
    public FindElements(TreeNode root)
    {
        
    }

    public bool Find(int target)
    {
        return false;
    }
}
public class Q1261_FindElementsInContaminatedBinaryTree
{
    public static TheoryData<TreeNode, List<int>, List<bool>> TestData => new()
    {
        {TreeNode.FromLevelOrderingIntArray([-1,null,-1])!, [1,2], [false, true]},
        {TreeNode.FromLevelOrderingIntArray([-1,-1,-1,-1,-1])!, [1,3,5], [true, true, false]},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(TreeNode tree, List<int> input, List<bool> expected)
    {
        var q = new FindElements(tree);
        for (var i = 0; i < input.Count; i++)
        {
            var actual = q.Find(input[i]);
            Assert.Equal(expected[i], actual);
        }
    }
}
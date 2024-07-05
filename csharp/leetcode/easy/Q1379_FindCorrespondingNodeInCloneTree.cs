class Q1379_FindCorrespondingNodeInCloneTree
{
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
    {
        return new TreeNode();
    }
}
class Q1379_FindCorrespondingNodeInCloneTreeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int?[]{7,4,3,null,null,6,19}, 3, 3],
        [new int?[]{7}, 7, 7],
        [new int?[]{8,null,6,null,5,null,4,null,3,null,2,null,1}, 4, 4],
    ];
}
public class Q1379_FindCorrespondingNodeInCloneTreeTest : TreeNodeTest
{
    [Theory]
    [ClassData(typeof(Q1379_FindCorrespondingNodeInCloneTreeTestData))]
    public void OfficialTestCases(int?[] input, int target, int expected)
    {
        var sut = new Q1379_FindCorrespondingNodeInCloneTree();
        var tree = TreeNode.FromLevelOrderingIntArray(input);
        var clone = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.GetTargetCopy(tree!, clone!, new TreeNode(target));
        Assert.Equal(expected, actual.val);
    }
}
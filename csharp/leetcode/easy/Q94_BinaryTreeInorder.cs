
public class Q94_BinaryTreeInorderTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] {new int?[]{1, null, 2, 3}, new int[]{1, 3, 2}},
        new object[] {Array.Empty<int?>(), Array.Empty<int>()},
        new object[] {new int?[]{1}, new int[]{1}},
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Q94_BinaryTreeInorderTests {
    [Theory]
    [ClassData(typeof(Q94_BinaryTreeInorderTestData))]
    public void OfficialTestCases(int?[] input, int[] expected) {
        var sut = new Q94_BinaryTreeInorder();
        var root = TreeNode.FromIntArray(input);
        var actual = sut.InorderTraversal(root);
        Assert.Equal(expected, actual);
    }
}
public class Q94_BinaryTreeInorder {
    public IList<int> InorderTraversal(TreeNode root) {
        return new List<int>();       
    }
}
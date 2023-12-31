
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

// Extra test cases provided by other developers
internal class Q94_BinaryTreeInorderExtraTestData : IEnumerable<object[]>
{
    private readonly List<object[]> _data =
    [
        [new int?[]{-26}, new int[]{-26}],
        [new int?[]{100,8,null,-83,null,48,null,72,null,-4}, Array.Empty<int>()],
        [new int?[]{97,78,32,80,79,29,-29,null,45,null,-20,null,-20,13,null,97,-41,-100,94,null}, new int[]{1}],
        [new int?[]{73,-55,76,null,71,-71,72,null,-63,null,-34,null,-9,null,-98,-19,-87,-83,63,-70,null,77,null,-36,null,-77,6,null,29,null}, new int[]{1}],
        [new int?[]{-72,11,-94,null,3,76,null,51,71,19,null,89,-62,null,-13,84,null,-66,55,-10,null,-99,-55,5,-40,20,null,-6,null,-60,null,39,null,38,-95,57,null,40,null,38}, new int[]{1}],
        [new int?[]{52,null,13,null,52,null,47,null,-75,-16,null,-10,null,7,99,10,null,20,null,15,-100,null,-37,67,0,-86,null,-96,25,null,68,-20,25,-28,-94,null,37,-22,null,65,-72,-24,null,90,19,null,86,-40,null,-7}, new int[]{1}],
        [new int?[]{36,null,9,null,62,66,null,56,97,55,null,51,-21,null,81,62,-88,null,-67,-40,null,-61,null,-79,98,null,37,-42,-60,-61,null,-70,-47,null,67,90,22,27,null,88,-34,null,43,67,-10,null,73,null,42,null,-21,1,-46,-58,null,33,null,72,-20,null,82,-23,null,87,27,null,-34,62,60,null,-49,null,-74,-5,null,49,null,-85,36,5,60,null,71,59,57,null,-68,55,null,-36,11,-18,null,-87,-91,null,-74,null,-17,-25}, new int[]{1}],
        [new int?[]{9,null,34,6,-17,null,-94,-54,60,-99,-30,null,100,null,-16,57,null,-90,-11,null,-17,null,-72,null,70,null,56,null,4,-65,null,-75,null,20,71,null,1,-7,-54,30,null,66,null,59,98,null,31,78,-7,-87,null,-4,25,96,-56,null,39,-63,null,-95,null,-37,80,null,-52,null,-85,31,null,51,null,3,82,null,-50,null,95,60,null,49,75,null,91,36,null,-27,null,-87,-13,null,96,null,87,null,19,null,-96,-69,null,-2}, new int[]{1}],
    ];

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Q94_BinaryTreeInorderTests {
    [Theory]
    [ClassData(typeof(Q94_BinaryTreeInorderTestData))]
    public void OfficialTestCases(int?[] input, int[] expected) {
        var sut = new Q94_BinaryTreeInorder();
        var root = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.InorderTraversal(root);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Q94_BinaryTreeInorderExtraTestData))]
    public void ExtraTestCases(int?[] input, int[] expected) {
        var sut = new Q94_BinaryTreeInorder();
        var root = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.InorderTraversal(root);
        Assert.Equal(expected, actual);
    }
}


public class Q94_BinaryTreeInorder {
    // take left, if no more left, go up, take self, take right, if no more right, go up

    public IList<int> InorderTraversal(TreeNode root) {
        return new List<int>();       
    }
}
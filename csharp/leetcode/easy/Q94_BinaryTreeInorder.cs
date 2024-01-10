namespace dojo.leetcode;
public class Q94_BinaryTreeInorderTestData : TestDataBase
{
    protected override List<object[]> Data =>
    [
        [new int?[] { 1, null, 2, 3 }, new int[] { 1, 3, 2 }],
        [Array.Empty<int?>(), Array.Empty<int>()],
        [new int?[] { 1 }, new int[] { 1 }],
    ];
}

// Extra test cases provided by other developers
internal class Q94_BinaryTreeInorderExtraTestData : TestDataBase
{
    protected override List<object[]> Data =>
    [
        [
            new int?[]{-26},
            new int[]{-26}],
        [
            new int?[]{100,8,null,-83,null,48,null,72,null,-4},
            new int[]{-4, 72, 48, -83, 8 , 100}
        ],
        [
            new int?[]{97,78,32,80,79,29,-29,null,45,null,-20,null,-20,13,null,97,-41,-100,94,null},
            new int[]{80, 97, 45, -41, 78, 79, -100, -20,94, 97, 29, -20, 32, 13,-29}
        ],
        [
            new int?[]{73,-55,76,null,71,-71,72,null,-63,null,-34,null,-9,null,-98,-19,-87,-83,63,-70,null,77,null,-36,null,-77,6,null,29,null},
            new int[]{-55, 71, -63, -70, -98,73, -71, 77,-19, -34, -36, -87, 76, 72,-77, -83, 6,-9, 63, 29}
        ],
        [
            new int?[]{-72,11,-94,null,3,76,null,51,71,19,null,89,-62,null,-13,84,null,-66,55,-10,null,-99,-55,5,-40,20,null,-6,null,-60,null,39,null,38,-95,57,null,40,null,38},
            new int[]{11, 38, 20, -66, 89, -6, 55, 51, -60, -10, -62,3, 71, 39, -99, -13, 38,-55, -95, -72,57, 5, 84,40, -40, 19, 76, -94}
        ],
        [
            new int?[]{52,null,13,null,52,null,47,null,-75,-16,null,-10,null,7,99,10,null,20,null,15,-100,null,-37,67,0,-86,null,-96,25,null,68,-20,25,-28,-94,null,37,-22,null,65,-72,-24,null,90,19,null,86,-40,null,-7},
            new int[]{52, 13, 52, 47, 67, 65, 68, -72, 15, -24, -20, 0, 90, 25,19, 10, -28,86, -86, -40, -94, -100, 7, -10, 20, -96, -7, 37, -37, -22, 25, 99, -16, -75}
        ],
        [
            new int?[]{36,null,9,null,62,66,null,56,97,55,null,51,-21,null,81,62,-88,null,-67,-40,null,-61,null,-79,98,null,37,-42,-60,-61,null,-70,-47,null,67,90,22,27,null,88,-34,null,43,67,-10,null,73,null,42,null,-21,1,-46,-58,null,33,null,72,-20,null,82,-23,null,87,27,null,-34,62,60,null,-49,null,-74,-5,null,49,null,-85,36,5,60,null,71,59,57,null,-68,55,null,-36,11,-18,null,-87,-91,null,-74,null,-17,-25},
            new int[]{36, 9, 55, 49, -58,27, -42, -40, -85, 33, 36,88, -60, 5,72, 60, -34,-20, 71, 81,56, 66, -61,43, 59, 82,  57, -61, 62, 51, -23, -68,67, -70, 55,87, -10, -36, 27, 11, -79, -47, 73, -18, -34, -88, 98, 67, -87, 62, -91, 42, 60, -74, 97, -21,-67, 90, -21,-49, -17, 37, 1, -25, -74, 22, -5, -46, 62}
        ],
        [
            new int?[]{9,null,34,6,-17,null,-94,-54,60,-99,-30,null,100,null,-16,57,null,-90,-11,null,-17,null,-72,null,70,null,56,null,4,-65,null,-75,null,20,71,null,1,-7,-54,30,null,66,null,59,98,null,31,78,-7,-87,null,-4,25,96,-56,null,39,-63,null,-95,null,-37,80,null,-52,null,-85,31,null,51,null,3,82,null,-50,null,95,60,null,49,75,null,91,36,null,-27,null,-87,-13,null,96,null,87,null,19,null,-96,-69,null,-2},
            new int[]{9, 6, 57, 49, -63, 75, 59, 20, -95, 91, 98,  70, 71, 36, -37, 31, -27, 80, -99, -94,-90, 56, 78, -87, -52, -13,1, -7, -85,96, -30, -11,31, 87, -87,-7, 4, 51, 19, -4, -54, 3, -96, 25, -69, 82, 34, -54, 100, 96, -2, -50, 30,-56, 95, -65,-17, -17, 60,-16, 66, 60,39, -75, -72}],
    ];
}

public class Q94_BinaryTreeInorderTests
{
    [Theory]
    [ClassData(typeof(Q94_BinaryTreeInorderTestData))]
    public void OfficialTestCases(int?[] input, int[] expected)
    {
        var sut = new Q94_BinaryTreeInorder();
        var root = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.InorderTraversal(root);
        Assert.Equal(expected, actual.ToArray());
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }

    [Theory]
    [ClassData(typeof(Q94_BinaryTreeInorderExtraTestData))]
    public void ExtraTestCases(int?[] input, int[] expected)
    {
        var sut = new Q94_BinaryTreeInorder();
        var root = TreeNode.FromLevelOrderingIntArray(input);
        var actual = sut.InorderTraversal(root);
        Assert.Equal(expected, actual.ToArray());
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}


public class Q94_BinaryTreeInorder
{
    public void InorderTraversal_Recursion(TreeNode? node, IList<int> result)
    {
        if (node != null)
        {
            InorderTraversal_Recursion(node.left, result);
            result.Add(node.val);
            InorderTraversal_Recursion(node.right, result);
        }
    }

    public void InorderTraversal_Loop(TreeNode root, IList<int> result)
    {
        var stack = new Stack<TreeNode>();
        TreeNode? current = root;

        while (current != null || stack.Count > 0)
        {
            // Down to deepest left first
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            result.Add(current.val);
            current = current.right;
        }
    }

    public IList<int> InorderTraversal(TreeNode? root)
    {
        var result = new List<int>();
        InorderTraversal_Loop(root!, result);
        return result;
    }
}
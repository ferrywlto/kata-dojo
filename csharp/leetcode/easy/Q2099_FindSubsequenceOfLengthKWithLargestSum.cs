public class Q2099_FindSubsequenceOfLengthKWithLargestSum
{
    private void SortStack(Stack<(int idx, int val)> stack, int i, int n, int maxDpeth)
    {
        var temp = new Stack<(int idx, int val)>();
        while (stack.Count != 0)
        {
            var peek = stack.Peek();
            if (peek.val < n)
            {
                peek = stack.Pop();
                temp.Push(peek);
            }
            else break;
        }
        if (stack.Count < maxDpeth) stack.Push((i, n));

        var spaceLeft = maxDpeth - stack.Count;
        for (var j = 0; j < spaceLeft; j++)
        {
            if (temp.Count > 0) stack.Push(temp.Pop());
        }
    }
    public int[] MaxSubsequence(int[] nums, int k)
    {
        var s = new Stack<(int idx, int val)>();
        for (var i = 0; i < nums.Length; i++)
        {
            SortStack(s, i, nums[i], k);
        }
        return s
            .OrderBy(x => x.idx)
            .Select(x => x.val)
            .ToArray();
    }
    public static List<object[]> TestData =>
    [
        [new int[]{2,1,3,3}, 2, new int[]{3,3}],
        [new int[]{-1,-2,3,4}, 3, new int[]{-1,3,4}],
        [new int[]{3,4,3,3}, 2, new int[]{3,4}],
        [new int[]{50,-75}, 2, new int[]{50,-75}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int[] expected)
    {
        var actual = MaxSubsequence(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q46_Permutatiuons
{
    // TC: O(n!) nPn = n!
    // SC: O(1)
    private readonly IList<IList<int>> _result = [];
    public IList<IList<int>> Permute(int[] nums)
    {
        Permute(nums, 0);
        return _result;
    }
    private void Permute(int[] nums, int startIdx)
    {
        if (startIdx == nums.Length) _result.Add(nums.ToList());
        else
        {
            for (var i = startIdx; i < nums.Length; i++)
            {
                SwapWith(nums, startIdx, i);
                Permute(nums, startIdx + 1);
                // Back track
                SwapWith(nums, startIdx, i);
            }
        }
    }
    private void SwapWith(int[] input, int fromIdx, int toIdx)
    {
        (input[fromIdx], input[toIdx]) = (input[toIdx], input[fromIdx]);
    }
    public static TheoryData<int[], IList<IList<int>>> TestData => new()
    {
        {[1,2,3], [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]},
        {[0,1], [[0,1],[1,0]]},
        {[1], [[1]]},
        {[5,4,6,2], [
            [4,5,6,2],[4,6,5,2],[4,6,2,5],[4,5,2,6],[4,2,5,6],[4,2,6,5],
            [6,4,2,5],[6,2,4,5],[6,2,5,4],[6,5,4,2],[6,5,2,4],[6,4,5,2],
            [2,6,5,4],[2,5,6,4],[2,5,4,6],[2,4,5,6],[2,4,6,5],[2,6,4,5],
            [5,2,4,6],[5,4,2,6],[5,4,6,2],[5,6,4,2],[5,6,2,4],[5,2,6,4],
        ]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, IList<IList<int>> expected)
    {
        var actual = Permute(input);
        Assert.Equal(expected.Count, actual.Count);
        expected = [.. expected.OrderBy(x => string.Join(',', x))];
        actual = [.. actual.OrderBy(x => string.Join(',', x))];
        Assert.Equal(expected, actual);
    }
}

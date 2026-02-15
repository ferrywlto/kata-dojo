public class Q3834_MergeAdjacentEqualElements
{
    public IList<long> MergeAdjacent(int[] nums)
    {
        var stack = new Stack<long>();
        stack.Push(nums[0]);

        for(var i=1; i<nums.Length; i++)
        {
            long current = nums[i];
            // go backward to the start
            while(stack.Count > 0 && stack.Peek() == current)
            {
                current += stack.Pop();
            }
            stack.Push(current);
        }

        return stack.Reverse().ToList();
    }
    public static TheoryData<int[], List<long>> TestData => new()
    {
        {[3,1,1,2], [3,4]},
        {[2,2,4], [8]},
        {[3,7,5], [3,7,5]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<long> expected)
    {
        var actual = MergeAdjacent(input);
        Assert.Equal(expected, actual);
    }
}

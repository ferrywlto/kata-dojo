public class Q2855_MinRightShiftsToSortArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), same as time to hold the temp list
    public int MinimumRightShifts(IList<int> nums)
    {
        var shifted = 0;
        var list = nums.ToList();
        if (IsSorted(list)) return shifted;

        while (shifted < nums.Count)
        {
            list = RightShift(list);
            shifted++;
            if (IsSorted(list)) return shifted;
        }
        return -1;
    }
    private static List<int> RightShift(List<int> input)
    {
        var last = input[^1];
        input.Remove(last);

        return input.Prepend(last).ToList();
    }
    private static bool IsSorted(List<int> input)
    {
        if (input.Count == 1) return true;
        for (var i = 1; i < input.Count; i++)
        {
            if (input[i - 1] > input[i]) return false;
        }
        return true;
    }
    public static TheoryData<IList<int>, int> TestData => new()
    {
        {new List<int>(){3,4,5,1,2}, 2},
        {new List<int>(){1,3,5}, 0},
        {new List<int>(){2,1,4}, -1},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(IList<int> input, int expected)
    {
        var actual = MinimumRightShifts(input);
        Assert.Equal(expected, actual
        ;
    }
}
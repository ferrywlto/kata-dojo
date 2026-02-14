public class Q2293_MinMaxGame
{
    // TC: O(n log 2), n scale with length of nums, shrink by factor of 2 each iteration
    // SC: O(n), n scale with length of nums initally, shrink by factor of 2 each time.  
    public int MinMaxGame(int[] nums)
    {
        var list = new List<int>(nums);
        while (list.Count > 1)
        {
            var temp = new List<int>();
            for (var i = 0; i < list.Count / 2; i++)
            {
                var val = i % 2 == 0
                    ? Math.Min(list[2 * i], list[2 * i + 1])
                    : Math.Max(list[2 * i], list[2 * i + 1]);
                temp.Add(val);
            }
            list = temp;
        }
        return list[0];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,3,5,2,4,8,2,2}, 1],
        [new int[] {70,38,21,22}, 22],
        [new int[] {3}, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinMaxGame(input);
        Assert.Equal(expected, actual);
    }
}

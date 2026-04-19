public class Q3903_SmallestStableIndexI
{
    public int FirstStableIndex(int[] nums, int k)
    {
        return 0;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [5, 0, 1, 4], 3, 3 }, { [3, 2, 1], 1, -1 }, { [0], 0, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = FirstStableIndex(input, k);
        Assert.Equal(expected, actual);
    }


}

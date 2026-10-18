public class Q4083_MinimumDeletionstoMakeArraySharp
{
    public int MinDeletions(int[] nums) {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 1, 2, 2, 2, 3], 3 },
        { [4, 4, 9, 4], 1}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinDeletions(input);
        Assert.Equal(expected, actual);
    }

}

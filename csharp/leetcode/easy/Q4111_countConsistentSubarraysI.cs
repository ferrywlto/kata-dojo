public class Q4111_countConsistentSubarraysI
{
    public int CountConsistent(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [5, 3, 1, 2], 6 },
        { [1, 1, 1], 6 },
        { [0], 1 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountConsistent(input);
        Assert.Equal(expected, actual);
    }
}

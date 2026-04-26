public class Q3909_CompareSumsOfBitonicParts
{
    public int CompareBitonicSums(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        { [1, 3, 2, 1], 1 },
        { [2, 4, 5, 2], 0 },
        { [1, 2, 4, 3], -1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CompareBitonicSums(input);
        Assert.Equal(expected, actual);
    }
}

public class Q3869_MinOperationsToTransformArrayIntoAlternatingPrime
{
    public int MinOperations(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new() { { [1, 2, 3, 4], 3 }, { [5, 6, 7, 8], 3 }, { [4, 4], 1 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

public class Q3866_FirstUniqueEvenElement
{
    public int FirstUniqueEven(int[] nums)
    {
        return 0;
    }

    public static TheoryData<int[], int> TestData => new() { { [3, 4, 2, 5, 4, 6], 2 }, { [4, 4], -1 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FirstUniqueEven(input);
        Assert.Equal(expected, actual);
    }
}

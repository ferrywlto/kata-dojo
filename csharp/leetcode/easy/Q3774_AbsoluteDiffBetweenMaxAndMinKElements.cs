public class Q3774_AbsoluteDiffBetweenMaxAndMinKElements
{
    public int AbsDifference(int[] nums, int k)
    {
        return 0;
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = AbsDifference(input, k);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<int[], int, int> TestData = new TheoryData<int[], int, int>() {
        {[5,2,2,4], 2, 5},
        {[100], 1, 0},
    };
}

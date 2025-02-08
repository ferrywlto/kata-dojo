public class Q3158_FindXORofNumbersWhichAppearTwice
{
    public int DuplicateNumbersXOR(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1,3], 1},
        {[1,2,3], 0},
        {[1,2,2,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DuplicateNumbersXOR(input);
        Assert.Equal(expected, actual);
    }
}
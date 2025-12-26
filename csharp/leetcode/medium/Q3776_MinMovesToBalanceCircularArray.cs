public class Q3776_MinMovesToBalanceCircularArray
{
    public long MinMoves(int[] balance)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5,1,-4], 4},
        {[1,2,-5,2], 6},
        {[-3,2], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinMoves(input);
        Assert.Equal(expected, actual);
    }
}

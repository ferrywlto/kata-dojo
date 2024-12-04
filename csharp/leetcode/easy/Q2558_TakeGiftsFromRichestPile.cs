public class Q2558_TakeGiftsFromRichestPile
{
    public long PickGifts(int[] gifts, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {25,64,9,4,100}, 4, 29],
        [new int[] {1,1,1,1}, 4, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, long expected)
    {
        var actual = PickGifts(input, k);
        Assert.Equal(expected, actual);
    }
}
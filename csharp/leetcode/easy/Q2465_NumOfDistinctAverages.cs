public class Q2465_NumOfDistinctAverages
{
    public int DistinctAverages(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,1,4,0,3,5}, 2],
        [new int[] {1,100}, 2],
        [new int[] {1,1,1,1}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = DistinctAverages(input);
        Assert.Equal(expected, actual);
    }
}
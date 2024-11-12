public class Q2404_MostFrequentEvenElement
{
    public int MostFrequentEven(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {0,1,2,2,4,4,1}, 2],
        [new int[] {4,4,4,9,2,4}, 4],
        [new int[] {29,47,21,41,13,37,25,7}, -1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MostFrequentEven(input);
        Assert.Equal(expected, actual);
    }
}

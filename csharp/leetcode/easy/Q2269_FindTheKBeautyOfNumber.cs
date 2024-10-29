public class Q2269_FindTheKBeautyOfNumber
{
    public int DivisorSubstrings(int num, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [240, 2, 2],
        [430043, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int k, int expected)
    {
        var actual = DivisorSubstrings(input, k);
        Assert.Equal(expected, actual);
    }
}
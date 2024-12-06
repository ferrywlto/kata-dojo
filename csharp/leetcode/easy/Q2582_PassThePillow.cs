public class Q2582_PassThePillow
{
    public int PassThePillow(int n, int time)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [4, 5, 2],
        [3, 2, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int time, int expected)
    {
        var actual = PassThePillow(input, time);
        Assert.Equal(expected, actual);
    }
}
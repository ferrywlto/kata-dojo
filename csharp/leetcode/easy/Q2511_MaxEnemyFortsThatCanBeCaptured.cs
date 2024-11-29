public class Q2511_MaxEnemyFortsThatCanBeCaptured
{
    public int CaptureForts(int[] forts)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,0,0,-1,0,0,0,0,1}, 4],
        [new int[] {0,0,1,-1}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CaptureForts(input);
        Assert.Equal(expected, actual);
    }
}


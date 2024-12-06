public class Q2582_PassThePillow
{
    // TC: O(time)
    // SC: O(1)
    public int PassThePillow(int n, int time)
    {
        var direction = 1;
        var pos = 1;
        var currentTime = 0;
        while (currentTime < time)
        {
            pos += direction;
            if (pos == n) direction = -1;
            else if (pos == 1) direction = 1;

            currentTime++;
        }
        return pos;
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
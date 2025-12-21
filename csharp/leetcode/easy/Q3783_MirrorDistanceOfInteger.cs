public class Q3783_MirrorDistanceOfInteger
{
    // TC: O(d), d scale with number of digits of n
    // SC: O(1), space used does not scale with input 
    public int MirrorDistance(int n)
    {
        if (n < 10) return 0;
        return Math.Abs(n - ReverseDigits(n));
    }
    private int ReverseDigits(int n)
    {
        var reversed = 0;
        while (n > 0)
        {
            var digit = n % 10;
            n /= 10;
            reversed *= 10;
            reversed += digit;
        }
        return reversed;
    }
    public static TheoryData<int, int> TestData => new()
    {
        {25 ,27},
        {10 ,9},
        {7 ,0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MirrorDistance(input);
        Assert.Equal(expected, actual);
    }
}

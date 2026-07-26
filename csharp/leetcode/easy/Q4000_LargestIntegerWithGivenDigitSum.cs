public class Q4000_LargestIntegerWithGivenDigitSum
{
    // TC: O(n)
    // SC: O(1)
    public int LargestInteger(int n, int s)
    {
        if (s == 0) return 0;

        var result = 0;
        while(n > 0)
        {
            if(s > 9)
            {
                s -= 9;
                result += 9;
            }
            else
            {
                result += s;
                s = 0;
            }
            n--;
            if(n > 0) result *= 10;
        }

        return s == 0 ? result : -1;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        { 2, 9, 90 },
        { 2, 19, -1 },
        { 5, 0, 0 },
        { 1, 1, 1 },
        { 3, 1, 100 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int s, int expected)
    {
        var actual = LargestInteger(n, s);
        Assert.Equal(expected, actual);
    }
}

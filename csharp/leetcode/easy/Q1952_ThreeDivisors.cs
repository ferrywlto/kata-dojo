public class Q1952_ThreeDivisors
{
    // TC: O(n), n scale with size of n
    // SC: O(1), space used does not sacle with input
    public bool IsThree(int n)
    {
        if (n % 2 == 0) return n == 4;

        var divideCount = 0;
        var limit = (int)Math.Ceiling(Math.Sqrt(n));
        for (var i = 3; i <= limit; i += 2)
        {
            if (n % i == 0)
            {
                if (i * i == n) divideCount++;
                else return false;
            }
        }
        return divideCount == 1;
    }

    public static List<object[]> TestData =>
    [
        [2, false],
        [4, true],
        [13, false],
        [9, true],
        [33, false],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var actual = IsThree(input);
        Assert.Equal(expected, actual);
    }
}
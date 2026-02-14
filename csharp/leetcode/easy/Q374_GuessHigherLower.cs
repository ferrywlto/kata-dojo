class GuessGame
{
    public int pick = 0;
    public int guess(int num)
    {
        if (pick > num) return 1;
        if (pick < num) return -1;
        return 0;
    }
}

class Q374_GuessNumberHigherLower : GuessGame
{
    // Also a binary search question, TC: O(log n), SC: O(1)
    public int GuessNumber(int n)
    {
        if (n == 1) return 1;

        long start = 0;
        long end = n;
        while (end - start > 1)
        {
            long middle = (end + start) / 2;
            // pick < middle
            var guessResult = guess((int)middle);
            if (guessResult < 0)
            {
                end = middle;
            }
            // pick > middle
            else if (guessResult > 0)
            {
                start = middle;
            }
            else return (int)middle;
        }
        if (guess((int)end) == 0) return (int)end;
        if (guess((int)start) == 0) return (int)start;
        return int.MinValue;
    }
}

class Q374_GuessNumberHigherLowerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [10, 6],
        [1, 1],
        [2, 1],
        [2, 2],
        [10000, 6]
    ];
}

public class Q374_GuessNumberHigherLowerTests
{
    [Theory]
    [ClassData(typeof(Q374_GuessNumberHigherLowerTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q374_GuessNumberHigherLower
        {
            pick = expected
        };
        var actual = sut.GuessNumber(input);
        Assert.Equal(expected, actual);
    }
}

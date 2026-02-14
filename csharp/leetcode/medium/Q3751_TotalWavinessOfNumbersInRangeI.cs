public class Q3751_TotalWavinessOfNumbersInRangeI
{
    // TC: O(n), where n scale with Abs(num1 - num2)
    // SC: O(1), space used does not scale with input
    public int TotalWaviness(int num1, int num2)
    {
        var result = 0;
        for (var i = num1; i <= num2; i++)
        {
            var temp = CalculateWaviness(i);
            result += temp;
        }
        return result;
    }

    private int CalculateWaviness(int input)
    {
        if (input < 100) return 0;
        var result = 0;

        var rightDight = input % 10;
        input /= 10;

        var middleDigit = input % 10;
        input /= 10;

        var leftDigit = input % 10;
        input /= 10;

        if (
            (middleDigit > leftDigit && middleDigit > rightDight) ||
            (middleDigit < leftDigit && middleDigit < rightDight)
        )
        {
            result++;
        }

        while (input > 0)
        {
            rightDight = middleDigit;
            middleDigit = leftDigit;
            leftDigit = input % 10;
            if (
                (middleDigit > leftDigit && middleDigit > rightDight) ||
                (middleDigit < leftDigit && middleDigit < rightDight)
            )
            {
                result++;
            }
            input /= 10;
        }
        return result;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        {120, 130, 3},
        {198, 202, 3},
        {4848, 4848, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int num1, int num2, int expected)
    {
        var actual = TotalWaviness(num1, num2);
        Assert.Equal(expected, actual);
    }
}

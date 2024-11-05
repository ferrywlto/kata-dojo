public class Q2335_MinAmountTimeToFillCups
{
    // TC: O(n), n scale with size of number in amount
    // SC: O(1), space used does not scale with input
    public int FillCups(int[] amount)
    {
        var result = 0;
        var maxIdx = new int[2];

        while (amount[0] > 0 || amount[1] > 0 || amount[2] > 0)
        {
            var max = 0;
            var sum = amount[0] + amount[1];

            if (sum > max)
            {
                max = sum;
                maxIdx[0] = 0;
                maxIdx[1] = 1;
            }

            sum = amount[1] + amount[2];
            if (sum > max)
            {
                max = sum;
                maxIdx[0] = 1;
                maxIdx[1] = 2;
            }

            sum = amount[0] + amount[2];
            if (sum > max)
            {
                maxIdx[0] = 0;
                maxIdx[1] = 2;
            }

            amount[maxIdx[0]]--;
            amount[maxIdx[1]]--;
            result++;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{1,4,2}, 4],
        [new int[]{5,4,4}, 7],
        [new int[]{5,0,0}, 5],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FillCups(input);
        Assert.Equal(expected, actual);
    }
}
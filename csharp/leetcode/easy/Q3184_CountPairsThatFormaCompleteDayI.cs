public class Q3184_CountPairsThatFormaCompleteDayI
{
    // TC: O(n^2), n scale with length of hours, n^2 due to all pairs
    // SC: O(1), space used does not scale with input
    public int CountCompleteDayPairs(int[] hours)
    {
        var result = 0;
        for (var i = 0; i < hours.Length - 1; i++)
        {
            for (var j = i + 1; j < hours.Length; j++)
            {
                long sum = hours[i] + hours[j];
                if (sum % 24 == 0) result++;
            }
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[12,12,30,24,24], 2},
        {[72,48,24,3], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountCompleteDayPairs(input);
        Assert.Equal(expected, actual);
    }
}
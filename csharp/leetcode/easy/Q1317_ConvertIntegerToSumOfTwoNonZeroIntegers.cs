class Q1317_ConvertIntegerToSumOfTwoNonZeroIntegers
{
    // TC: O(n), it have to iterate at least half the elements in worst case to check if all numbers contains no zero
    // SC: O(1), no space used for calculation
    public int[] GetNoZeroIntegers(int n)
    {
        if (n == 2) return [1, 1];
        var times = n / 2;
        if (n % 2 != 0) times++;
        // try brute force method
        for (var i = 1; i < times; i++)
        {
            var compement = n - i;
            if (HasZeroInDigits(compement) || HasZeroInDigits(i)) continue;
            else return [i, compement];
        }

        return [];
    }
    public bool HasZeroInDigits(int input)
    {
        while (input > 0)
        {
            if (input % 10 == 0) return true;
            input /= 10;
        }
        return false;
    }
}
class Q1317_ConvertIntegerToSumOfTwoNonZeroIntegersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [2, new int[2]{1,1}],
        [3, new int[2]{1,2}],
        [11, new int[2]{2,9}],
    ];
}
public class Q1317_ConvertIntegerToSumOfTwoNonZeroIntegersTests
{
    [Theory]
    [ClassData(typeof(Q1317_ConvertIntegerToSumOfTwoNonZeroIntegersTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q1317_ConvertIntegerToSumOfTwoNonZeroIntegers();
        var actual = sut.GetNoZeroIntegers(input);
        Assert.Equal(expected, actual);
    }
}

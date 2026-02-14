class Q1304_FindNUniqueIntegersSumUpToZero
{
    // TC: O(n), n = input
    // SC: O(n), n/2 + 1 space needed to return the result
    public int[] SumZero(int n)
    {
        var times = n / 2;
        var result = new List<int>();
        for (var i = 1; i <= times; i++)
        {
            result.Add(-i);
            result.Add(i);
        }
        if (n % 2 != 0) result.Add(0);
        return result.ToArray();
    }
    public int[] SumZero_Faster(int n)
    {
        var result = new int[n];
        var value = 1;
        for (var i = 0; i < n - 1; i += 2)
        {
            result[i] = value;
            result[i + 1] = -value;
            value++;
        }
        return result;
    }
}
class Q1304_FindNUniqueIntegersSumUpToZeroTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [5, new int[]{-7,-1,1,3,4}],
        [3, new int[]{-1,0,1}],
        [1, new int[]{0}],
    ];
}
public class Q1304_FindNUniqueIntegersSumUpToZeroTests
{
    [Theory]
    [ClassData(typeof(Q1304_FindNUniqueIntegersSumUpToZeroTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q1304_FindNUniqueIntegersSumUpToZero();
        var actual = sut.SumZero_Faster(input);
        var distinctCount = actual.Distinct().Count();
        var actualSum = actual.Sum();

        Assert.Equal(input, distinctCount);
        Assert.Equal(expected.Distinct().Count(), distinctCount);
        Assert.Equal(0, actualSum);
        Assert.Equal(expected.Sum(), actualSum);
    }
}

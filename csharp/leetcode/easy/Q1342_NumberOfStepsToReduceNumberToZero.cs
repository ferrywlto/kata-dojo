class Q1342_NumberOfStepsToReduceNumberToZero
{
    // TC: O(n), scale with size of num
    // SC: O(1), no space used in calculation
    public int NumberOfSteps(int num)
    {
        var count = 0;
        while (num > 0)
        {
            if (num % 2 == 0) num /= 2;
            else num -= 1;
            count++;
        }
        return count;
    }
    // TC: O(n), scale with bits of num
    // SC: O(1), no space used in calculation
    public int NumberOfSteps_BitwiseOps(int num)
    {
        if (num == 0) return 0;
        var count = 0;
        while(num > 0)
        {
            if ((num & 1) == 1) count++;
            num >>= 1;
            count++;
        }
        return count-1;
    }
}
class Q1342_NumberOfStepsToReduceNumberToZeroTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [14, 6],
        [8, 4],
        [123, 12],
    ];
}
public class Q1342_NumberOfStepsToReduceNumberToZeroTests
{
    [Theory]
    [ClassData(typeof(Q1342_NumberOfStepsToReduceNumberToZeroTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1342_NumberOfStepsToReduceNumberToZero();
        var actual = sut.NumberOfSteps_BitwiseOps(input);
        Assert.Equal(expected, actual);
    }
}
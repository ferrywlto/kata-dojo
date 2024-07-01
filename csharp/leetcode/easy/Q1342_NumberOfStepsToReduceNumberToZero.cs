
class Q1342_NumberOfStepsToReduceNumberToZero
{
        public int NumberOfSteps(int num) {
        return 0;
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
        var actual = sut.NumberOfSteps(input);
        Assert.Equal(expected, actual);
    }
}
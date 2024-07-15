class Q1450_NumOfStudentsDoingHomeworkAtGivenTime
{
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
    {
        return 0;
    }
}
class Q1450_NumOfStudentsDoingHomeworkAtGivenTimeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3}, new int[] {3,2,7}, 4, 1],
        [new int[] {4}, new int[] {4}, 4, 1],
    ];
}
public class Q1450_NumOfStudentsDoingHomeworkAtGivenTimeTests
{
    [Theory]
    [ClassData(typeof(Q1450_NumOfStudentsDoingHomeworkAtGivenTimeTestData))]
    public void OfficialTestCases(int[] start, int[] end, int q, int expected)
    {
        var sut = new Q1450_NumOfStudentsDoingHomeworkAtGivenTime();
        var actual = sut.BusyStudent(start, end, q);
        Assert.Equal(expected, actual);
    }
}
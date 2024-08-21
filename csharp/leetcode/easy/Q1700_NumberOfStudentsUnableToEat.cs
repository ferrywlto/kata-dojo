class Q1700_NumberOfStudentsUnableToEat
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        return 0;
    }
}
class Q1700_NumberOfStudentsUnableToEatTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,1,0,0}, new int[] {0,1,0,1}, 0],
        [new int[] {1,1,1,0,0,1}, new int[] {1,0,0,0,1,1}, 3],
    ];
}
public class Q1700_NumberOfStudentsUnableToEatTests
{
    [Theory]
    [ClassData(typeof(Q1700_NumberOfStudentsUnableToEatTestData))]
    public void OfficialTestCases(int[] students, int[] sandwiches, int expected)
    {
        var sut = new Q1700_NumberOfStudentsUnableToEat();
        var actual = sut.CountStudents(students, sandwiches);
        Assert.Equal(expected, actual);
    }
}
class Q1742_MaxNumberOfBallsInBox
{
    public int CountBalls(int lowLimit, int highLimit) 
    {
        return 0;
    }
}
class Q1742_MaxNumberOfBallsInBoxTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [1,10,2],
        [5,15,2],
        [19,28,2],
    ];
}
public class Q1742_MaxNumberOfBallsInBoxTests
{
    [Theory]
    [ClassData(typeof(Q1742_MaxNumberOfBallsInBoxTestData))]
    public void OfficialTestCases(int low, int high, int expected)
    {
        var sut = new Q1742_MaxNumberOfBallsInBox();
        var actual = sut.CountBalls(low, high);
        Assert.Equal(expected, actual);
    }
}
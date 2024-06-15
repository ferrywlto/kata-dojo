
class Q1189_MaximumNUmberOfBalloons
{
        public int MaxNumberOfBalloons(string text) {
        return 0;   
    }
}
class Q1189_MaximumNUmberOfBalloonsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["nlaebolko", 1],
        ["loonbalxballpoon", 2],
        ["leetcode", 0],
    ];
}
public class Q1189_MaximumNUmberOfBalloonsTests
{
    [Theory]
    [ClassData(typeof(Q1189_MaximumNUmberOfBalloonsTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1189_MaximumNUmberOfBalloons();
        var actual = sut.MaxNumberOfBalloons(input);
        Assert.Equal(expected, actual);
    }
}

class Q1137_NthTribonaacciNumber
{
    public int Tribonacci(int n) 
    {
        return 0;
    }    
}
class Q1137_NthTribonaacciNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [4,4],
        [25,1389537],
    ];
}
public class Q1137_NthTribonaacciNumberTests
{
    [Theory]
    [ClassData(typeof(Q1137_NthTribonaacciNumberTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1137_NthTribonaacciNumber();
        var actual = sut.Tribonacci(input);
        Assert.Equal(expected, actual);
    }
}
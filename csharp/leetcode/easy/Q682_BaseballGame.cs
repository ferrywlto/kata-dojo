namespace dojo.leetcode;

public class Q682_BaseballGame
{
    public int CalPoints(string[] operations) 
    {
        return 0;    
    }
}

public class Q682_BaseballGameTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[]{"5","2","C","D","+"}, 30],
        [new string[]{"5","-2","4","C","D","9","+","+"}, 27],
        [new string[]{"1","C"}, 0],
    ];
}

public class Q682_BaseballGameTests
{
    [Theory]
    [ClassData(typeof(Q682_BaseballGameTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q682_BaseballGame();
        var actual = sut.CalPoints(input);
        Assert.Equal(expected, actual);
    }
}
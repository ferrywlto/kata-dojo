public class Q3110_ScoreOfString
{
    public int ScoreOfString(string s) 
    {
        return 0;    
    }    
    public static TheoryData<string, int> TestData => new ()
    {
        {"hello", 13},
        {"zaz", 50},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = ScoreOfString(input);
        Assert.Equal(expected, actual);
    }
}
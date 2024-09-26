public class Q1974_MinTimeToTypeWordUsingSpecialTypewriter
{
    public int MinTimeToType(string word) 
    {
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        ["abc", 5],
        ["bza", 7],
        ["zjpc", 34],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinTimeToType(input);
        Assert.Equal(expected, actual);
    }
}
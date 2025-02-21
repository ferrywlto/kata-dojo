public class Q3340_CheckBalancedString
{
    public bool IsBalanced(string num) 
    {
        return false;    
    }    
    public static TheoryData<string, bool> TestData => new ()
    {
        {"1234", false},
        {"24123", true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsBalanced(input);
        Assert.Equal(expected, actual);
    }
}

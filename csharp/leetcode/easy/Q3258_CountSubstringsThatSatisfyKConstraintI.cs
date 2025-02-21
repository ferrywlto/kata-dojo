public class Q3258_CountSubstringsThatSatisfyKConstraintI
{
    public int CountKConstraintSubstrings(string s, int k) 
    {
        return 0;    
    }    
    public static TheoryData<string, int, int> TestData => new ()
    {
        {"10101", 1, 12},
        {"1010101", 2, 25},
        {"11111", 1, 15},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, int expected)
    {
        var actual = CountKConstraintSubstrings(input, k);
        Assert.Equal(expected, actual);
    }
}
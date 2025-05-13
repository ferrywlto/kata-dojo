public class Q1415_KthLexicographicalStringOfAllHappyStringsOfLengthN
{
    public string GetHappyString(int n, int k) {
     return string.Empty;   
    }    
    public static TheoryData<int, int, string> TestData => new ()
    {
        {1, 3, "c"},
        {1, 4, ""},
        {3, 9, "cab"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, string expected)
    {
        var actual = GetHappyString(input1, input2);
        Assert.Equal(expected, actual);
    }
}
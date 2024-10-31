public class Q2224_MinNumberOfOperationsToConvertTime
{
    public int ConvertTime(string current, string correct) 
    {
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        ["02:30", "04:35", 3],
        ["11:00", "11:01", 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, int expected)
    {
        var actual = ConvertTime(input1, input2);
        Assert.Equal(expected, actual);
    }
}

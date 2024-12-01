public class Q2544_AlternatingDigitSum
{
    public int AlternateDigitSum(int n) 
    {
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        [521, 4],
        [111, 1],
        [886996, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = AlternateDigitSum(input);
        Assert.Equal(expected, actual);
    }
}
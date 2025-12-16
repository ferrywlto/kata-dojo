public class Q3751_TotalWavinessOfNumbersInRangeI
{
    public int TotalWaviness(int num1, int num2) {
     return 0;   
    }    
    public static TheoryData<int, int, int> TestData => new ()
    {
        {120, 130, 3},
        {198, 202, 3},
        {4848, 4848, 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int num1, int num2, int expected)
    {
        var actual = TotalWaviness(num1, num2);
        Assert.Equal(expected, actual);
    }
}

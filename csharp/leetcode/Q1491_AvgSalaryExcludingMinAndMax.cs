
class Q1491_AvgSalaryExcludingMinAndMax
{
    public double Average(int[] salary) 
    {
        return 0;    
    }    
}
class Q1491_AvgSalaryExcludingMinAndMaxTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {4000,3000,1000,2000}, 2500.00000],
        [new int[] {1000,2000,3000}, 2000.00000],
    ];
}
public class Q1491_AvgSalaryExcludingMinAndMaxTests
{
    [Theory]
    [ClassData(typeof(Q1491_AvgSalaryExcludingMinAndMaxTestData))]
    public void OfficialTestCases(int[] input, double expected)
    {
        var sut = new Q1491_AvgSalaryExcludingMinAndMax();
        var actual = sut.Average(input);
        Assert.Equal(expected, actual);
    }
}
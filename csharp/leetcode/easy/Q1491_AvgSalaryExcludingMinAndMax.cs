class Q1491_AvgSalaryExcludingMinAndMax
{
    // TC: O(n), where n is the length of salary, have to iterate all to find the min and max
    // SC: O(1), space used is fixed to 3 integer variables
    public double Average(int[] salary)
    {
        var max = int.MinValue;
        var min = int.MaxValue;
        var sum = 0;
        foreach (var s in salary)
        {
            if (s > max) max = s;
            if (s < min) min = s;
            sum += s;
        }
        sum -= max;
        sum -= min;
        return Math.Round((double)sum / (salary.Length - 2), 5);
    }
}
class Q1491_AvgSalaryExcludingMinAndMaxTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {4000,3000,1000,2000}, 2500.00000],
        [new int[] {1000,2000,3000}, 2000.00000],
        [new int[] {48000,59000,99000,13000,78000,45000,31000,17000,39000,37000,93000,77000,33000,28000,4000,54000,67000,6000,1000,11000}, 41111.11111],
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
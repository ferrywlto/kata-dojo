public class Q2469_ConvertTheTemperature
{
    // TC: O(1)
    // SC: O(1)
    public double[] ConvertTemperature(double celsius)
    {
        return [celsius + 273.15d, celsius * 1.8d + 32.00d];
    }
    public static List<object[]> TestData =>
    [
        [36.50, new double[] {309.65000,97.70000}],
        [122.11, new double[] {395.26000,251.79800}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(double input, double[] expected)
    {
        var actual = ConvertTemperature(input);
        Assert.Equal(expected, actual);
    }
}

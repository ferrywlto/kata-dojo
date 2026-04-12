public class Q3899_AnglesOfTriangle
{
    public double[] InternalAngles(int[] sides)
    {
        return [];
    }

    public static TheoryData<int[], double[]> TestData =>
        new() { { [3, 4, 5], [36.86990, 53.13010, 90.00000] }, { [2, 4, 2], [] } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, double[] expected)
    {
        var actual = InternalAngles(input);
        Assert.Equal(expected, actual);
    }
}

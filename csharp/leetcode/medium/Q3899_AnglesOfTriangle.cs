public class Q3899_AnglesOfTriangle
{
    // TC: O(1)
    // SC: O(1)
    public double[] InternalAngles(int[] sides)
    {
        var sideA = sides[0];
        var sideB = sides[1];
        var sideC = sides[2];

        if (sideA + sideB <= sideC ||
            sideB + sideC <= sideA ||
            sideC + sideA <= sideB) return [];

        // set sideA on vertical axis, sideB on horizontal axis
        // var coordA = (0, sideA);
        // var coordB = (sideB, 0);
        // Cater if not right angle -> Use law of cosine
        // a² = b² + c² - 2bc cos(A)
        // if A is 90 degree -> cos(90) = 0 thus a² = b² + c²
        // 2bc cos(A) is the correction term for angle not being 90 degree.
        // It comes from how much one side projects onto the other.

        var angleA = RadianToDegree(FindAngle(sideA, sideB, sideC));
        var angleB = RadianToDegree(FindAngle(sideB, sideC, sideA));
        var angleC = 180 - angleA - angleB;

        Span<double> result = [Format(angleA), Format(angleB), Format(angleC)];
        result.Sort();

        return result.ToArray();
    }

    private static double FindAngle(int sideA, int sideB, int sideC) => Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / ((double)2 * sideB * sideC));
    private static double Format(double input) => Math.Round(input, 5);
    private static double RadianToDegree(double input) => input * 180 / Math.PI;

    public static TheoryData<int[], double[]> TestData =>
        new()
        {
            { [3, 4, 5], [36.86990, 53.13010, 90.00000] },
            { [2, 4, 2], [] },
            { [1, 1, 1], [60.0, 60.0, 60.0] },
            { [1, 4, 4], [14.36151, 82.81924, 82.81924] }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, double[] expected)
    {
        var actual = InternalAngles(input);
        Assert.Equal(expected, actual);
    }
}

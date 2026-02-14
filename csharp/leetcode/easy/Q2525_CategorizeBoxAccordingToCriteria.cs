public class Q2525_CategorizeBoxAccordingToCriteria
{
    // TC: O(1)
    // SC: O(1)
    public string CategorizeBox(int length, int width, int height, int mass)
    {
        const long bulkyDimension = 10000;

        var isBulky = (long)length * width * height >= 1_000_000_000L
            || length >= bulkyDimension
            || width >= bulkyDimension
            || height >= bulkyDimension;

        var isHeavy = mass >= 100;

        if (isBulky && isHeavy) return "Both";
        if (!isBulky && !isHeavy) return "Neither";
        if (isBulky && !isHeavy) return "Bulky";
        if (!isBulky && isHeavy) return "Heavy";

        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        [1000, 35, 700, 300, "Heavy"],
        [200, 50, 800, 50, "Neither"],
        [2909, 3968, 3272, 727, "Both"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int length, int width, int height, int mass, string expected)
    {
        var actual = CategorizeBox(length, width, height, mass);
        Assert.Equal(expected, actual);
    }
}

public class Q2525_CategorizeBoxAccordingToCriteria
{
    public string CategorizeBox(int length, int width, int height, int mass)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        [1000, 35, 700, 300, "Heavy"],
        [200, 50, 800, 50, "Neither"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int length, int width, int height, int mass, string expected)
    {
        var actual = CategorizeBox(length, width, height, mass);
        Assert.Equal(expected, actual);
    }
}
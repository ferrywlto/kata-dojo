public class Q3024_TypeOfTriangle
{
    public string TriangleType(int[] nums)
    {
        return string.Empty;
    }
    public static TheoryData<int[], string> TestData => new()
    {
        {[3,3,3], "equilateral"},
        {[3,4,5], "scalene"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, string expected)
    {
        var actual = TriangleType(input);
        Assert.Equal(expected, actual);
    }
}
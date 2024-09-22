public class Q1952_ThreeDivisors(ITestOutputHelper output) : TestBase(output)
{
    public bool IsThree(int n)
    {
        return false;
    }

    public static List<object[]> TestData =>
    [
        [2, false],
        [4, true],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var actual = IsThree(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2315_CountAsterisks
{
    public int CountAsterisks(string s)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["l|*e*et|c**o|*de|", 2],
        ["iamprogrammer", 0],
        ["yo|uar|e**|b|e***au|tifu|l", 5],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountAsterisks(input);
        Assert.Equal(expected, actual);
    }
}
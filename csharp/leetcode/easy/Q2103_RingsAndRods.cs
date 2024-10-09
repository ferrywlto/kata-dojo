public class Q2103_RingsAndRods
{
    public int CountPoints(string rings) 
    {
        return 0;    
    }
    public static List<object[]> TestData =>
    [
        ["B0B6G0R6R0R6G9", 1],
        ["B0R0G0R9R0B0G0", 1],
        ["G4", 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = CountPoints(input);
        Assert.Equal(expected, actual);
    }
}
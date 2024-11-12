public class Q2399_CheckDistancesBetweenSameLetters
{
    public bool CheckDistances(string s, int[] distance)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        ["abaccb", new int[] {1,3,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, true],
        ["aa", new int[] {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int[] d, bool expected)
    {
        var actual = CheckDistances(input, d);
        Assert.Equal(expected, actual);
    }
}
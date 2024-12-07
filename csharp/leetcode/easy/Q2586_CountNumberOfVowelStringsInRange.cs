public class Q2586_CountNumberOfVowelStringsInRange
{
    public int VowelStrings(string[] words, int left, int right)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"are","amy","u"}, 0, 2, 2],
        [new string[] {"hey","aeo","mu","ooo","artro"}, 1, 4, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int left, int right, int expected)
    {
        var actual = VowelStrings(input, left, right);
        Assert.Equal(expected, actual);
    }
}
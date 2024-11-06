public class Q2347_BestPokerHand
{
    public string BestHand(int[] ranks, char[] suits)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {13,2,3,1,9}, new char[] {'a','a','a','a','a'}, "Flush"],
        [new int[] {4,4,2,4,4}, new char[] {'d','a','a','b','c'}, "Three of a Kind"],
        [new int[] {10,10,2,12,9}, new char[] {'a','b','c','a','d'}, "Pair"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] ranks, char[] suits, string expected)
    {
        var actual = BestHand(ranks, suits);
        Assert.Equal(expected, actual);
    }
}
public class Q2347_BestPokerHand
{
    public string BestHand(int[] ranks, char[] suits)
    {
        var sSet = suits.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        if (sSet.Count == 1) return "Flush";

        var maxCount = 0;
        var rSet = ranks.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
        foreach(var p in rSet)
        {
            if (p.Value > maxCount) maxCount = p.Value;
        }
        return maxCount switch {
            >= 3 => "Three of a Kind",
            2 => "Pair",
            1 => "High Card", 
            _ => "Error"
        };
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
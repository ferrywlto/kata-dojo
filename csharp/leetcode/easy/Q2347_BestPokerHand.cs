public class Q2347_BestPokerHand
{
    // TC: O(n), n scale with length of ranks and length of suits, in only one pass
    // SC: O(m), m scale with unique ranks plus unique suits
    public string BestHand(int[] ranks, char[] suits)
    {
        var set = new HashSet<char>(suits);
        if (set.Count == 1) return "Flush";

        var maxCount = 0;
        var dict = new Dictionary<int, int>();
        foreach (var r in ranks)
        {
            if (dict.TryGetValue(r, out var val)) dict[r] = ++val;
            else dict.Add(r, 1);

            if (dict[r] > maxCount) maxCount = dict[r];
        }
        return maxCount switch
        {
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
        [new int[] {13,12,3,4,7}, new char[] {'a','d','c','b','c'}, "High Card"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] ranks, char[] suits, string expected)
    {
        var actual = BestHand(ranks, suits);
        Assert.Equal(expected, actual);
    }
}

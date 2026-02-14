public class Q3839_NumPrefixConnectedGroups
{
    // TC: O(n), n scale with length of words
    // SC: O(n), worst case all prefix are unique
    public int PrefixConnected(string[] words, int k)
    {
        var prefixSetAll = new HashSet<string>();
        var prefixSetAtLeastTwo = new HashSet<string>();
        foreach (var w in words)
        {
            if (w.Length < k) continue;

            var prefix = w[0..k];
            if (!prefixSetAll.Add(prefix))
                prefixSetAtLeastTwo.Add(prefix);
        }
        return prefixSetAtLeastTwo.Count;
    }

    public static TheoryData<string[], int, int> TestData => new()
    {
        {["apple","apply","banana","bandit"], 2, 2},
        {["car","cat","cartoon"], 3 , 1},
        {["bat","dog","dog","doggy","bat"], 3, 2}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int k, int expected)
    {
        var actual = PrefixConnected(input, k);
        Assert.Equal(expected, actual);
    }

}

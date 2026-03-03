using System.Text;

public class Q3853_MergeCloseCharacters
{
    // TC: O(n), n scale with length of s
    // SC: O(n) for storing result, otherwise O(1)
    public string MergeCharacters(string s, int k)
    {
        Span<int> lastIndexes = stackalloc int[26];
        for (var i = 0; i < lastIndexes.Length; i++) lastIndexes[i] = -1;

        var sb = new StringBuilder();

        foreach (var t in s)
        {
            var idx = t - 'a';
            if (lastIndexes[idx] == -1 || sb.Length - lastIndexes[idx] > k)
            {
                sb.Append(t);
                lastIndexes[idx] = sb.Length - 1;
            }
        }
        return sb.ToString();
    }

    public static TheoryData<string, int, string> TestData => new()
    {
        { "abca", 3, "abc" }, { "aabca", 2, "abca" }, { "yybyzybz", 2, "ybzybz" },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, string expected)
    {
        var actual = MergeCharacters(input, k);
        Assert.Equal(expected, actual);
    }
}

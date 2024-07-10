class Q1408_StringMatchingInArray
{
    // TC: O(n^2), n log n for Array.Sort() + n*n-1 for the matching
    // SC: O(n), one list of n holding all existed string, another list of n holding all strings worse case
    public IList<string> StringMatching(string[] words)
    {
        if (words.Length <= 1) return [];
        // sort by the length first
        // longest one is not possible be substring of any string
        // start from the second longest, it can only be substring of previous existed strings
        var result = new List<string>();
        Array.Sort(words, new LengthComparer());

        var existed = new List<string>() { words[^1] };
        for (var i = words.Length - 2; i >= 0; i--)
        {
            foreach (var w in existed)
            {
                if (w.Contains(words[i]))
                {
                    result.Add(words[i]);
                    break;
                }
            }
            existed.Add(words[i]);
        }
        return result;
    }
    class LengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x?.Length > y?.Length) return 1;
            else if (y?.Length > x?.Length) return -1;
            else return 0;
        }
    }
}
class Q1408_StringMatchingInArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"mass","as","hero","superhero"}, new string[] {"as","hero"}],
        [new string[] {"leetcode","et","code"}, new string[] {"et","code"}],
        [new string[] {"blue","green","bu"}, Array.Empty<string>()],
        [new string[] {"leetcoder","leetcode","od","hamlet","am"}, new string[] {"leetcode","od","am"}],
    ];
}
public class Q1408_StringMatchingInArrayTests
{
    [Theory]
    [ClassData(typeof(Q1408_StringMatchingInArrayTestData))]
    public void OfficialTestCases(string[] input, string[] expected)
    {
        var sut = new Q1408_StringMatchingInArray();
        var actual = sut.StringMatching(input);
        Assert.Equal(expected.Length, actual.Count);

        foreach (var w in actual)
        {
            Assert.Contains(w, expected);
        }
    }
}
public class Q3330_FindQriginalTypedStringI
{
    // TC: O(n), n scale with length of word
    // SC: O(1), space used does not scale with input
    public int PossibleStringCount(string word)
    {
        if (word.Length == 1) return 1;

        var result = 0;
        var last = word[0];
        var len = 0;
        for (var i = 1; i < word.Length; i++)
        {
            var ch = word[i];
            if (ch == last)
            {
                if (len == 0) len = 2;
                else len++;
            }
            else
            {
                last = ch;
                if (len > 0)
                {
                    result += len - 1;
                    len = 0;
                }
            }
        }
        if (len > 0) result += len - 1;
        // The 1 means the original word, that had no mistakes 
        return 1 + result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abbcccc", 5},
        {"abcd", 1},
        {"aaaa", 4},
        {"ere", 1},
        {"erree", 3},
        // errreeer
        // errreeerr
        // errrerrr
        // errreerrr
        // ereeerrr
        // erreeerrr
        {"errreeerrr", 7},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = PossibleStringCount(input);
        Assert.Equal(expected, actual);
    }
}

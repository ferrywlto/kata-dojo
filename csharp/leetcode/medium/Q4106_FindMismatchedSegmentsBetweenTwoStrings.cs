public class Q4106_FindMismatchedSegmentsBetweenTwoStrings
{
    // TC: O(n)
    // SC: O(n)
    public IList<IList<string>> FindMismatchedSegments(string s1, string s2)
    {
        var result = new List<IList<string>>();
        var lastSame = -1;
        var diff = 0;
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i]) diff++;
            else
            {
                if (diff > 0)
                {
                    result.Add([
                        s1.Substring(lastSame == -1 ? 0 : lastSame + 1, diff),
                        s2.Substring(lastSame == -1 ? 0 : lastSame + 1, diff)
                    ]);
                    diff = 0;
                }

                lastSame = i;
            }
        }

        if (diff > 0)
        {
            result.Add([
                s1.Substring(lastSame + 1, diff),
                s2.Substring(lastSame + 1, diff)
            ]);
        }

        return result;
    }

    public static TheoryData<string, string, IList<List<string>>> TestData => new()
    {
        { "earth", "empty", [["ar", "mp"], ["h", "y"]] },
        { "action", "nation", [["ac", "na"]] },
        { "hot", "hot", [] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s1, string s2, IList<List<string>> expected)
    {
        var actual = FindMismatchedSegments(s1, s2);
        Assert.Equal(expected, actual);
    }
}

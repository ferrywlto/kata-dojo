using System.Text;

public class Q4106_FindMismatchedSegmentsBetweenTwoStrings
{
    public IList<IList<string>> FindMismatchedSegments(string s1, string s2)
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();
        var result = new List<List<string>>();

        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                sb1.Append(s1[i]);
                sb2.Append(s2[i]);
            }
            else if(sb1.Length > 0)
            {
                result.Add([sb1.ToString(), sb2.ToString()]);
                sb1.Clear();
                sb2.Clear();
            }
        }
        if(sb1.Length > 0)
            result.Add([sb1.ToString(), sb2.ToString()]);
        return [.. result];
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

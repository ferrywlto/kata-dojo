using System.Text;

public class Q3324_FindSequenceOfStringsAppearedOnScreen
{
    // TC: O(n), n scale with length of target
    // SC: O(n), to store the intermediate string
    public IList<string> StringSequence(string target)
    {
        var sb = new StringBuilder();

        var result = new List<string>();

        for (var i = 0; i < target.Length; i++)
        {
            sb.Append('a');
            result.Add(sb.ToString());
            while (sb[i] != target[i])
            {
                sb[i]++;
                result.Add(sb.ToString());
            }
        }

        return result;
    }
    public static TheoryData<string, IList<string>> TestData => new()
    {
        {"abc", ["a","aa","ab","aba","abb","abc"]},
        {"he", ["a","b","c","d","e","f","g","h","ha","hb","hc","hd","he"]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, IList<string> expected)
    {
        var actual = StringSequence(input);
        Assert.Equal(expected, actual);
    }
}

using System.Text;

public class Q2129_CapitalizeTitle
{
    // TC: O(n), n scale with length of title, in only one pass
    // SC: O(n), n scale with length of title, for StringBuilder 
    public string CapitalizeTitle(string title)
    {
        var charCount = 0;
        var sb = new StringBuilder(title);
        sb.Append(' ');

        for (var i = 0; i < sb.Length; i++)
        {
            var c = sb[i];
            if (c != ' ') charCount++;
            else
            {
                var startIdx = i - charCount;
                if (charCount > 2)
                {
                    sb[startIdx] = char.ToUpper(sb[startIdx]);
                    startIdx++;
                }
                for (var j = startIdx; j < i; j++)
                {
                    sb[j] = char.ToLower(sb[j]);
                }
                charCount = 0;
            }
        }
        sb.Length--;
        return sb.ToString();
    }
    public static List<object[]> TestData =>
    [
        ["capiTalIze tHe titLe", "Capitalize The Title"],
        ["capiTalIzE tHE titLE", "Capitalize The Title"],
        ["First leTTeR of EACH Word", "First Letter of Each Word"],
        ["i lOve leetcode", "i Love Leetcode"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = CapitalizeTitle(input);
        Assert.Equal(expected, actual);
    }
}

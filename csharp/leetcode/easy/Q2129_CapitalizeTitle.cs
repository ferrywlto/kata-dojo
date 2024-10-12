using System.Text;

public class Q2129_CapitalizeTitle
{
    // TC: O(n), n scale with length of title, in only one pass
    // SC: O(n), n scale with length of title, for StringBuilder 
    public string CapitalizeTitle(string title)
    {
        var charCount = 0;
        var sb = new StringBuilder(title);
        for (var i = 0; i < sb.Length; i++)
        {
            var c = title[i];
            if (c != ' ') charCount++;
            else
            {
                if (charCount == 2)
                {
                    sb[i - 2] = char.ToLower(sb[i - 2]);
                    sb[i - 1] = char.ToLower(sb[i - 1]);
                }
                else if (charCount == 1)
                {
                    sb[i - 1] = char.ToLower(sb[i - 1]);
                }
                else
                {
                    sb[i - charCount] = char.ToUpper(sb[i - charCount]);
                    for (var j = i - charCount + 1; j < i; j++)
                    {
                        sb[j] = char.ToLower(sb[j]);
                    }
                }
                charCount = 0;
            }
        }

        if (charCount == 2)
        {
            sb[^2] = char.ToLower(sb[^2]);
            sb[^1] = char.ToLower(sb[^1]);
        }
        else if (charCount == 1)
        {
            sb[^1] = char.ToLower(sb[^1]);
        }
        else
        {
            sb[^charCount] = char.ToUpper(sb[^charCount]);
            for (var j = sb.Length - charCount + 1; j < sb.Length; j++)
            {
                sb[j] = char.ToLower(sb[j]);
            }
        }
        return sb.ToString();
    }
    public static List<object[]> TestData =>
    [
        ["capiTalIze tHe titLe", "Capitalize The Title"],
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
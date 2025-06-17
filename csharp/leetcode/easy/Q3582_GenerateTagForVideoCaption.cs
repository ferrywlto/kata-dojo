using System.Text;

public class Q3582_GenerateTagForVideoCaption//(ITestOutputHelper output)
{
    // TC: O(n), n scale with length of caption
    // SC: O(n), worst case the caption contains only one word
    public string GenerateTag(string caption)
    {
        // add the first 99 letters
        var sb = new StringBuilder("#");
        var words = caption.Trim().Split(' ');

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            for (var j = 0; j < word.Length; j++)
            {
                if (!char.IsAsciiLetter(word[j])) continue;

                if (i > 0 && j == 0)
                {
                    sb.Append(char.ToUpper(word[j]));
                }
                else
                {
                    sb.Append(char.ToLower(word[j]));
                }

                if (sb.Length == 100) return sb.ToString();
            }
        }

        return sb.ToString();
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"Leetcode daily streak achieved", "#leetcodeDailyStreakAchieved"},
        {"Leetcode dAily streak achieved", "#leetcodeDailyStreakAchieved"},
        {"can I Go There", "#canIGoThere"},
        {" fPysaRtLQLiMKVvRhMkkDLNedQKffPnCjbITBTOVhoVjiKbfSawvpisDaNzXJctQkn", "#fpysartlqlimkvvrhmkkdlnedqkffpncjbitbtovhovjikbfsawvpisdanzxjctqkn"},
        {"hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh", "#hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh"},
        {"Bold apple beyond bright future crash mountains glow light gently dance waits shore breeze mind ", "#boldAppleBeyondBrightFutureCrashMountainsGlowLightGentlyDanceWaitsShoreBreezeMind"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = GenerateTag(input);
        Assert.Equal(expected, actual);
    }
}
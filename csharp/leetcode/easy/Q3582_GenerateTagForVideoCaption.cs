public class Q3582_GenerateTagForVideoCaption
{
    public string GenerateTag(string caption)
    {
        return "";
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"Leetcode daily streak achieved", "#leetcodeDailyStreakAchieved"},
        {"can I Go There", "#canIGoThere"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = GenerateTag(input);
        Assert.Equal(expected, actual);
    }
}
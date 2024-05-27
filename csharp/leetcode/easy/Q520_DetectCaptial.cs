class Q520_DetectCaptial
{
    // TC: O(n)
    // SC: O(1)
    public bool DetectCapitalUse(string word)
    {
        // 3 cases
        // 1. all lower
        // 2. all Upper
        // 3. only the first is upper
        if (word.Length == 1) return true;

        var capCase = 2; // Ab
        if (char.IsLower(word[0])) capCase = 0; // a
        else if (char.IsUpper(word[0]) && char.IsUpper(word[1])) capCase = 1; // AA

        return capCase switch
        {
            0 => RestAllLower(word, 1),
            1 => RestAllUpper(word, 2),
            _ => RestAllLower(word, 2),
        };
    }

    private bool RestAllUpper(string word, int startIdx)
    {
        for (var i = startIdx; i < word.Length; i++)
        {
            if (!char.IsUpper(word[i])) return false;
        }
        return true;
    }
    private bool RestAllLower(string word, int startIdx)
    {
        for (var i = startIdx; i < word.Length; i++)
        {
            if (!char.IsLower(word[i])) return false;
        }
        return true;
    }
}

class Q520_DetectCaptialTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["USA", true],
        ["leetcode", true],
        ["Google", true],
        ["FlaG", false],
    ];
}

public class Q520_DetectCaptialTests
{
    [Theory]
    [ClassData(typeof(Q520_DetectCaptialTestData))]
    public void OfficialTestCases(string input, bool expected)
    {
        var sut = new Q520_DetectCaptial();
        var actual = sut.DetectCapitalUse(input);
        Assert.Equal(expected, actual);
    }
}
namespace dojo.leetcode;

public class Q520_DetectCaptial
{
    // TC: O(n)
    // SC: O(1)
    public bool DetectCapitalUse(string word)
    {
        // 3 rules
        // 1. all lower
        // 2. all Upper
        // 3. only the first is upper
        if (word.Length == 1) return true;
        
        // a
        var firstIsLower = char.IsLower(word[0]);
        if(firstIsLower)
        {
            return RestAllLower(word, 1);
        }
        // Aa
        var secondIsLower = char.IsLower(word[1]);
        if(secondIsLower)
        {
            return RestAllLower(word, 2);
        }
        // AA
        for (var i=2; i<word.Length; i++)
        {
            if (!char.IsUpper(word[i])) return false;
        }
        return true;        
    }

    private bool RestAllLower(string word, int startIdx)
    {
        for (var i=startIdx; i<word.Length; i++)
        {
            if (!char.IsLower(word[i])) return false;
        }
        return true;
    }
}

public class Q520_DetectCaptialTestData: TestData
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
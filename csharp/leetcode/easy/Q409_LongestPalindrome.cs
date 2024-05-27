class Q409_LongestPalindrome
{
    // TC: O(n), SC: O(n)
    public int LongestPalindrome(string s)
    {
        // 1. analyze
        // 2. if s.length is odd, check dict have only 1 odd char and all others are even
        // 3. if s.length is even, check if all chars are even 
        var dict = s.Analyze();
        var hasOdd = false;
        var sumOfEven = 0;
        var sumOfOdd = 0;
        foreach(var kv in dict)
        {
            if (kv.Value % 2 == 0)
            {
                sumOfEven += kv.Value;
            }
            else
            {
                hasOdd = true;
                sumOfOdd += kv.Value - 1;
            }
        }
        var result = sumOfEven + sumOfOdd;

        return hasOdd ? result + 1 : result;
    }
}

class Q409_LongestPalindromeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abccccdd", 7],
        ["a", 1],
        ["bb", 2],
        ["ccc", 3],
        ["aaaCCC", 5], // aCCCa, not 3 
        ["civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth", 983],
    ];
}

public class Q409_LongestPalindromeTests
{
    [Theory]
    [ClassData(typeof(Q409_LongestPalindromeTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q409_LongestPalindrome();
        var actual = sut.LongestPalindrome(input);
        Assert.Equal(expected, actual);
    }
}
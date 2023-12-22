using System.Security.Principal;

public class Q14_LongestCommonPrefixTests 
{
    [Theory]
    [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new string[] { "flower", "flower", "flower", "flower" }, "flower")]
    [InlineData(new string[] { "dog", "racecar", "car" }, "")]
    public void OfficialTestCases(string[] strs, string expected)
    {
        var result = new Q14_LongestCommonPrefix().LongestCommonPrefix(strs);
        Assert.Equal(expected, result);
    }
}


// Consider the following case: ["abcde","abcd","abcdef","abcdefg","something else"]
// Always only need to check the first character in first word, which is "a"
// Obviously "" is the longest common prefix
// Second case: ["abcde","abcd","abcdef","abcdefg"]
// The possible longest prefix is "abcd", so the first fail case indicate the existing prefix is already the longest  
public class Q14_LongestCommonPrefix
{
    // Speed: 69ms (99.92%), Memory: 42.99MB (7.97%)
    public string LongestCommonPrefix(string[] strs)
    {
        // No need to check as constraints already defined 1 <= strs.Length <= 200
        // if (strs.Length == 0) return "";
        if (strs.Length == 1) return strs[0];

        var word = strs[0];
        var wordLength = word.Length;
        if (wordLength == 0 || word.Equals("")) return "";

        string prefix = "";
        for (byte i = 0; i<=wordLength; i++ ) {
            var current = word.Substring(0,i);
            for (byte j=1; j<strs.Length; j++) {
                if (!strs[j].StartsWith(current)) {
                    return prefix;
                }
            }
            prefix = current;
        }
        return prefix;
    }
}
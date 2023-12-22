using System.Security.Principal;
using System.Text;

public class Q14_LongestCommonPrefixTests 
{
    [Theory]
    [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new string[] { "flower", "flower", "flower", "flower" }, "flower")]
    [InlineData(new string[] { "dog", "racecar", "car" }, "")]
    public void OfficialTestCases(string[] strs, string expected)
    {
        var result = new Q14_LongestCommonPrefix().LongestCommonPrefix_Reverse(strs);
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

    // A reverse approach, start from the end of the word
    // Speed: 70ms (99.88%), Memory: 42.34MB (8.22%)
    public string LongestCommonPrefix_Reverse(string[] strs)
    {
        // No need to check as constraints already defined 1 <= strs.Length <= 200
        if (strs.Length == 1) return strs[0];

        StringBuilder word = new(strs[0]);
        if (word.Length == 0 || word.Equals("")) return "";

        for (byte j=1; j<strs.Length; j++) {
            if (word.Length > strs[j].Length) {
                word.Remove(strs[j].Length, word.Length - strs[j].Length);
            }

            for (var i = word.Length-1; i>=0; i-- ) {
                if (!strs[j][i].Equals(word[i])) {
                    word.Remove(i, word.Length - i);
                }
            }

            if (word.Length <= 0) {
                return "";
            }
        }
        return word.ToString();
    }
}
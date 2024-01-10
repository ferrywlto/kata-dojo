namespace dojo.leetcode;

using System.Collections.Generic;
using System.Text;

public class Q14_LongestCommonPrefixTestData : TestDataBase
{
    protected override List<object[]> Data => 
    [
        [new string[] { "flower", "flow", "flight" }, "fl"],
        [new string[] { "flower", "flower", "flower", "flower" }, "flower"],
        [new string[] { "dog", "racecar", "car" }, ""],
        [new string[] { "ab", "a" }, "a"]
    ];
}

public class Q14_LongestCommonPrefixTests
{
    [Theory]
    [ClassData(typeof(Q14_LongestCommonPrefixTestData))]
    public void OfficialTestCases(string[] strs, string expected)
    {
        var result = new Q14_LongestCommonPrefix().LongestCommonPrefix_Char(strs);
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
    // Inspired by others, use char instead of string, once the first char has been proved common prefix, no need to keep checking in other rounds
    // Speed: 61ms (100%), Memory: 42.1MB (8.55%)
    public string LongestCommonPrefix_Char(string[] strs)
    {
        if (strs.Length == 0) return "";
        if (strs.Length == 1) return strs[0];

        var word = strs[0].ToCharArray();
        var wordLength = word.Length;
        if (wordLength == 0 || word.Equals("")) return "";

        byte idx = 0;
        for (byte i = 0; i < wordLength; i++)
        {
            var current = word[i];
            for (byte j = 1; j < strs.Length; j++)
            {

                if (i >= strs[j].Length || strs[j][i] != current)
                {
                    return strs[0][..idx];
                }
            }
            idx++;
        }
        return strs[0][..idx];
    }

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
        for (byte i = 0; i <= wordLength; i++)
        {
            var current = word.Substring(0, i);
            for (byte j = 1; j < strs.Length; j++)
            {
                if (!strs[j].StartsWith(current))
                {
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

        for (byte j = 1; j < strs.Length; j++)
        {
            if (word.Length > strs[j].Length)
            {
                word.Remove(strs[j].Length, word.Length - strs[j].Length);
            }

            for (var i = word.Length - 1; i >= 0; i--)
            {
                if (!strs[j][i].Equals(word[i]))
                {
                    word.Remove(i, word.Length - i);
                }
            }

            if (word.Length <= 0)
            {
                return "";
            }
        }
        return word.ToString();
    }
}
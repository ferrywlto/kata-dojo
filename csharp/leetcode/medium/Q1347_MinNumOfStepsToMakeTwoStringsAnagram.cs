public class Q1347_MinNumOfStepsToMakeTwoStringsAnagram
{
    // TC: O(n), n scale with length of s and t
    // SC: O(1), space used does not scale with input
    public int MinSteps(string s, string t)
    {
        var freqS = new int[26];
        var freqT = new int[26];
        for (var i = 0; i < s.Length; i++) freqS[s[i] - 'a']++;
        for (var j = 0; j < t.Length; j++) freqT[t[j] - 'a']++;

        var result = 0;
        for (var k = 0; k < 26; k++)
        {
            if (freqT[k] > freqS[k])
            {
                result += freqT[k] - freqS[k];
            }
        }
        return result;
    }
    public static TheoryData<string, string, int> TestData => new()
    {
        {"bab", "aba", 1},
        {"leetcode", "practice", 5},
        {"anagram", "mangaar", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, int expected)
    {
        var actual = MinSteps(input1, input2);
        Assert.Equal(expected, actual);
    }
}

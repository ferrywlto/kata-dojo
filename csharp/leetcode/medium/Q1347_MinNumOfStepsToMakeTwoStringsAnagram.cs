public class Q1347_MinNumOfStepsToMakeTwoStringsAnagram
{
    public int MinSteps(string s, string t)
    {
        var freq = new int[26];
        for (var i = 0; i < s.Length; i++)
        {
            freq[s[i] - 'a']++;
        }
        for (var j = 0; j < t.Length; j++)
        {
            freq[t[j] - 'a']--;
        }

        var result = 0;
        for (var k = 0; k < freq.Length; k++)
        {
            result += freq[k] < 0 ? -freq[k] : freq[k];
        }
        return result / 2;
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
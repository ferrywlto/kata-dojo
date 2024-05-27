class Q459_RepeatedSubstring
{
    // TC: O(n^2), SC: O(n)
    public bool RepeatedSubstringPattern(string s)
    {
        if (s.Length <= 1) return false;
        if (s.Length == 2) return s[0] == s[1];
        // from window size 1 to s.Length/2
        // if s % substring.Length != 0 skip
        // n = s / substring .Length
        // repeat temp += substring n times
        // if temp == s return true 

        var windowSize = s.Length / 2;
        // Console.WriteLine($"windowSize: {windowSize}");
        for (var i=windowSize; i>0; i--)
        {
            if (s.Length % i != 0) continue;

            var substr = s[..i];
            for (var j=i; j<s.Length; j++) 
            {
                // Console.WriteLine($"subStr: {string.Join(string.Empty, substr)}, subStr[{j%i}]: {substr[j % i]}, s[{j}: {s[j]}] ");
                if (!substr[j % i].Equals(s[j])) break;
                if (j == s.Length - 1) return true;
            }
        }
        return false;
    }

    // TC: O(n), SC: O(n)
    // This make use of the property of duplicating a string, the original string will appear in the middle only if the original string compose of repeated substring
    // e.g. bbc -> bbcbbc -> bcbb -> false
    // e.g. bcbc -> bcbcbcbc -> cbcbcb -> true
    public bool RepeatedSubstringPattern_Faster(string s)
    {
        if (s.Length == 0) return false;

        var dup = s + s;
        return dup[1..^1].Contains(s);
    }
}

class Q459_RepeatedSubstringTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["abab", true],
        ["aba", false],
        ["abcabcabcabc", true],
        ["abcdabcdabcd", true],
        ["abcabcabc", true],
        ["abcabcab", false],
        ["abcabc", true],
        ["abcab", false],
        ["abc", false],
        ["abcdadcba", false],
        ["abcdaabcd", false],
        ["abcdefghiabcdefghabcdefghabcdefghiabcdefghabcdefghabcdefghiabcdefghabcdefghabcdefghiabcdefghabcdefghi", false],
        ["abcdefghiabcdefghabcdefghiabcdefghabcdefghiabcdefghiabcdefghiabcdefghabcdefghiabcdefghabcdefghiabcdefghi", true],
        ["ab", false],
        ["a", false],
        ["", false],
    ];
}

public class Q459_RepeatedSubstringTests
{
    [Theory]
    [ClassData(typeof(Q459_RepeatedSubstringTestData))]
    public void Test_RepeatedSubstringPattern(string s, bool expected)
    {
        var sut = new Q459_RepeatedSubstring();
        var actual = sut.RepeatedSubstringPattern_Faster(s);
        Assert.Equal(expected, actual);
    }
}
public class Q3692_MajorityFrequencyCharacters
{
    // TC: O(n), n scale with s.Length
    // SC: O(1), space used does not scale with input
    public string MajorityFrequencyGroup(string s)
    {
        return "0";
    }

    public static TheoryData<string, string> TestData =>
        new()
        {
            { "aaabbbccdddde", "ab" },
            { "abcd", "abcd" },
            { "pfpfgi", "fp" }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string expected)
    {
        var result = MajorityFrequencyGroup(s);
        Assert.Equal(expected, result);
    }
}

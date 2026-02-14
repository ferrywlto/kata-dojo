public class Q3813_VowelConsonantScore
{
    private readonly HashSet<char> Vowels = ['a', 'e', 'i', 'o', 'u'];
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int VowelConsonantScore(string s)
    {
        var cCount = 0;
        var vCount = 0;
        foreach (var c in s)
        {
            if (char.IsAsciiLetter(c))
            {
                if (Vowels.Contains(char.ToLower(c))) vCount++;
                else cCount++;
            }
        }
        return cCount == 0 ? 0 : (int)Math.Floor((double)vCount / cCount);
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"cooear", 2},
        {"axeyizou", 1},
        {"au 123", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = VowelConsonantScore(input);
        Assert.Equal(expected, actual);
    }
}

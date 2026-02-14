public class Q2027_MinimumMovesToConvertString
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int MinimumMoves(string s)
    {
        var moves = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 'X')
            {
                moves++;
                i += 2;
            }
        }

        return moves;
    }
    public static TheoryData<string, int> TestData => new()
    {
      {"XXX", 1},
      {"XXOX", 2},
      {"OOOO", 0},
      {"XXXOOXXX", 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumMoves(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2027_MinimumMovesToConvertString
{
    public int MinimumMoves(string s)
    {
        var minMoves = int.MaxValue;

        for (var k = 0; k < 3; k++)
        {
            var moves = 0;
            for (var i = k; i < s.Length; i += 3)
            {
                var targetIdx = Math.Min(i + 3, s.Length);

                for (var j = i; j < targetIdx; j++)
                {
                    if (s[j] == 'X')
                    {
                        moves++;
                        break;
                    }
                }
            }
            if (k == 1 && s[0] == 'X') moves++;
            else if (k == 2 && (s[0] == 'X' || s[1] == 'X'))
            {
                moves++;
            }
            if (moves < minMoves)
            {
                minMoves = moves;
            }
        }
        return minMoves;
    }
    public static TheoryData<string, int> TestData => new()
    {
      {"XXX", 1},
      {"XXOX", 2},
      {"OOOO", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumMoves(input);
        Assert.Equal(expected, actual);
    }
}
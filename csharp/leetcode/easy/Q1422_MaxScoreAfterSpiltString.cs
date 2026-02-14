class Q1422_MaxScoreAfterSpiltString
{
    // TC: O(n), n for initial left and right score, + n-1 ops for sliding window calculate new scores  
    // SC: O(1), comparisons doing in-place
    public int MaxScore(string s)
    {
        var leftScore = 0;
        var rightScore = 0;

        if (s[0] == '0') leftScore++;
        for (var i = s.Length - 1; i >= 1; i--)
        {
            if (s[i] == '1') rightScore++;
        }
        var max = leftScore + rightScore;
        for (var j = 1; j < s.Length - 1; j++)
        {
            if (s[j] == '0') leftScore++;
            else rightScore--;

            if (leftScore + rightScore > max)
                max = leftScore + rightScore;
        }
        return max;
    }
}
class Q1422_MaxScoreAfterSpiltStringTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["011101", 5],
        ["00111", 5],
        ["00110", 4],
        ["00101", 4],
        ["10101", 3],
        ["01001", 4],
        ["1111", 3],
        ["0000", 3],
    ];
}
public class Q1422_MaxScoreAfterSpiltStringTests
{
    [Theory]
    [ClassData(typeof(Q1422_MaxScoreAfterSpiltStringTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1422_MaxScoreAfterSpiltString();
        var actual = sut.MaxScore(input);
        Assert.Equal(expected, actual);
    }
}

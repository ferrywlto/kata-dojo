class Q1189_MaximumNUmberOfBalloons
{
    private const string balloon = "balloon";
    // TC: O(n), n is length of text
    // SC: O(n), n is length of text
    public int MaxNumberOfBalloons(string text)
    {
        var charsCount = text
            .GroupBy(c => c)
            .ToDictionary(grp => grp.Key, grp => grp.Count());

        var balloonCount = 0;
        while(true)
        {
            for(var i=0; i<balloon.Length; i++)
            {
                if (!charsCount.TryGetValue(balloon[i], out var count) || count == 0) return balloonCount;
                charsCount[balloon[i]] = --count;
            }
            balloonCount++;
        }
    }
    // TC: O(n), n is length of text
    // SC: O(1) the size of dict is fixed
    public int MaxNumberOfBalloons_Faster(string text)
    {
        var dict = new Dictionary<char, int>() {
            {'b', 0},
            {'a', 0},
            {'l', 0},
            {'o', 0},
            {'n', 0},
        };
        for(var i=0; i<text.Length; i++)
        {
            if (dict.ContainsKey(text[i]))
            {
                dict[text[i]]++;
            }
        }
        dict['l'] /= 2;
        dict['o'] /= 2;
        return dict.Min(x => x.Value);
    }    
}
class Q1189_MaximumNUmberOfBalloonsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["nlaebolko", 1],
        ["loonbalxballpoon", 2],
        ["leetcode", 0],
        ["balon", 0],
        ["balonbalon", 1],
        ["balloonballoonballon", 2],
    ];
}
public class Q1189_MaximumNUmberOfBalloonsTests
{
    [Theory]
    [ClassData(typeof(Q1189_MaximumNUmberOfBalloonsTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q1189_MaximumNUmberOfBalloons();
        var actual = sut.MaxNumberOfBalloons_Faster(input);
        Assert.Equal(expected, actual);
    }
}
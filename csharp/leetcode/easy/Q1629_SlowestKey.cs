class Q1629_SlowestKey
{
    // TC: O(n) where n is length of releaseTimes
    // SC: O(n) where n is the unique characters of releaseTimes for the dictionary to track the time 
    public char SlowestKey(int[] releaseTimes, string keysPressed)
    {
        var slowestKey = keysPressed[0];
        var maxTime = releaseTimes[0];
        var dict = new Dictionary<char, int>() { { slowestKey, maxTime } };

        for (var i = 1; i < releaseTimes.Length; i++)
        {
            var tempTime = releaseTimes[i] - releaseTimes[i - 1];

            if (dict.TryGetValue(keysPressed[i], out var value))
            {
                if (tempTime > value) dict[keysPressed[i]] = tempTime;
            }
            else dict.Add(keysPressed[i], tempTime);

            if (tempTime > maxTime) maxTime = tempTime;
        }

        return dict
            .Where(x => x.Value == maxTime)
            .Select(x => x.Key)
            .OrderByDescending(x => x)
            .First();
    }
}
class Q1629_SlowestKeyTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {100,101}, "cb", 'c'],
        [new int[] {100,101}, "cc", 'c'],
        [new int[] {100,200}, "ac", 'c'],
        [new int[] {9,29,49,50}, "cbcd", 'c'],
        [new int[] {12,23,36,46,62}, "spuda", 'a'],
    ];
}
public class Q1629_SlowestKeyTests
{
    [Theory]
    [ClassData(typeof(Q1629_SlowestKeyTestData))]
    public void OfficialTestCases(int[] input, string keys, char expected)
    {
        var sut = new Q1629_SlowestKey();
        var actual = sut.SlowestKey(input, keys);
        Assert.Equal(expected, actual);
    }
}
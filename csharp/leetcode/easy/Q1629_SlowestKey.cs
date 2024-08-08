class Q1629_SlowestKey
{
    // TC: O(n) where n is length of releaseTimes
    // SC: O(1) where n is the unique characters of releaseTimes for the dictionary to track the time 
    public char SlowestKey(int[] releaseTimes, string keysPressed)
    {
        char slowestKey = keysPressed[0];
        int maxTime = releaseTimes[0];

        for (int i = 1; i < releaseTimes.Length; i++)
        {
            int tempTime = releaseTimes[i] - releaseTimes[i - 1];
            char currentKey = keysPressed[i];

            if (tempTime > maxTime || (tempTime == maxTime && currentKey > slowestKey))
            {
                maxTime = tempTime;
                slowestKey = currentKey;
            }
        }

        return slowestKey;
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
class Q1629_SlowestKey
{
    public char SlowestKey(int[] releaseTimes, string keysPressed)
    {
        return '\0';
    }
}
class Q1629_SlowestKeyTestData : TestData
{
    protected override List<object[]> Data => 
    [
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
class Q1394_FindLuckyIntegerInArray
{
    // TC: O(n), n is length of arr
    // SC: O(n), n is unique values of arr
    public int FindLucky(int[] arr)
    {
        var dict = arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var match = dict.Where(x => x.Key == x.Value).Select(x => x.Key);
        if(match.Any()) return match.Max();
        return -1;
    }
}
class Q1394_FindLuckyIntegerInArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {2,2,3,4}, 2],
        [new int[] {1,2,2,3,3,3}, 3],
        [new int[] {2,2,2,3,3}, -1],
    ];
}
public class Q1394_FindLuckyIntegerInArrayTests
{
    [Theory]
    [ClassData(typeof(Q1394_FindLuckyIntegerInArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1394_FindLuckyIntegerInArray();
        var actual = sut.FindLucky(input);
        Assert.Equal(expected, actual);
    }
}
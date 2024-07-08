class Q1394_FindLuckyIntegerInArray
{
    public int FindLucky(int[] arr)
    {
        return 0;
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
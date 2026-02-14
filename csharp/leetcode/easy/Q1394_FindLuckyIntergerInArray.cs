class Q1394_FindLuckyIntegerInArray
{
    // TC: O(n), n is length of arr
    // SC: O(n), n is unique values of arr
    public int FindLucky(int[] arr)
    {
        var dict2 = new Dictionary<int, int>();
        foreach (var num in arr)
        {
            if (dict2.TryGetValue(num, out var value))
            {
                dict2[num] = ++value;
            }
            else
            {
                dict2.Add(num, 1);
            }
        }
        var max = -1;
        foreach (var p in dict2)
        {
            if (p.Key == p.Value && p.Key > max) max = p.Key;
        }
        return max;
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

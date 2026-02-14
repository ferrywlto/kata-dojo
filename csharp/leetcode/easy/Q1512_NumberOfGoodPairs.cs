
class Q1512_NumberOfGoodPairs
{
    // TC: O(n), where n is length of nums as all items need to iterate once
    // TC: O(m), where m is the number of unique numbers in nums
    public int NumIdenticalPairs(int[] nums)
    {
        var pairs = 0;
        var dict = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!dict.TryGetValue(n, out var value)) dict.Add(n, 0);
            else
            {
                dict[n] = ++value;
                pairs += value;
            }
        }
        return pairs;
    }
}
class Q1512_NumberOfGoodPairsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,1,1,3}, 4],
        [new int[] {1,1,1}, 3],
        [new int[] {1,1,1,1}, 6],
        [new int[] {1,2,3}, 0],
    ];
}
public class Q1512_NumberOfGoodPairsTests
{
    [Theory]
    [ClassData(typeof(Q1512_NumberOfGoodPairsTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1512_NumberOfGoodPairs();
        var actual = sut.NumIdenticalPairs(input);
        Assert.Equal(expected, actual);
    }
}

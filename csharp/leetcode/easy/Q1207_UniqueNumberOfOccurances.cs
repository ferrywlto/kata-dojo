class Q1207_UniqueNumberOfOccurances
{
    // TC: O(n), n is length of arr
    // SC: O(n), n is distinct element in arr
    public bool UniqueOccurrences(int[] arr)
    {
        var dict = arr
            .GroupBy(n => n)
            .ToDictionary(grp => grp.Key, grp => grp.Count());
        var occurances = dict.Select(x => x.Value).ToList();
        return occurances.Count
            == occurances.ToHashSet().Count;
    }
}
class Q1207_UniqueNumberOfOccurancesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,2,1,1,3}, true],
        [new int[]{1,2}, false],
        [new int[]{-3,0,1,-3,1,1,1,-3,10,0}, true],
    ];
}
public class Q1207_UniqueNumberOfOccurancesTests
{
    [Theory]
    [ClassData(typeof(Q1207_UniqueNumberOfOccurancesTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1207_UniqueNumberOfOccurances();
        var actual = sut.UniqueOccurrences(input);
        Assert.Equal(expected, actual);
    }
}
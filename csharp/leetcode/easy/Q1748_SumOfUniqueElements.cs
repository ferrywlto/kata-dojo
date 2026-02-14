class Q1748_SumOfUniqueElements
{
    // TC: O(n+m), where n is length of nums and m is number of unique numbers
    // SC: O(m), where m is number of unique numbers in nums   
    public int SumOfUniqueLINQ(int[] nums)
    {
        return nums
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count())
            .Where(x => x.Value == 1)
            .Select(x => x.Key)
            .Sum();
    }

    public int SumOfUnique(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (dict.TryGetValue(n, out var value))
            {
                dict[n] = ++value;
            }
            else
            {
                dict.Add(n, 1);
            }
        }
        var result = 0;
        foreach (var d in dict)
        {
            if (d.Value == 1) result += d.Key;
        }
        return result;
    }
}
class Q1748_SumOfUniqueElementsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,3,2}, 4],
        [new int[] {1,1,1,1,1}, 0],
        [new int[] {1,2,3,4,5}, 15],
    ];
}
public class Q1748_SumOfUniqueElementsTests
{
    [Theory]
    [ClassData(typeof(Q1748_SumOfUniqueElementsTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1748_SumOfUniqueElements();
        var actual = sut.SumOfUnique(input);
        Assert.Equal(expected, actual);
    }
}

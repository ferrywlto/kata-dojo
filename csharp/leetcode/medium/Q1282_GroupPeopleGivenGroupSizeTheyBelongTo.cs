public class Q1282_GroupPeopleGivenGroupSizeTheyBelongTo
{
    // TC: O(n * m), n scale with length of group size, m scale with number of different group sizes
    // SC: O(m)
    public IList<IList<int>> GroupThePeople(int[] groupSizes)
    {
        var dict = new Dictionary<int, List<int>>();
        for (var i = 0; i < groupSizes.Length; i++)
        {
            var size = groupSizes[i];
            if (!dict.TryGetValue(size, out var val))
            {
                dict.Add(size, [i]);
            }
            else
            {
                val.Add(i);
            }
        }
        var result = new List<IList<int>>();
        foreach (var p in dict)
        {
            var size = p.Key;
            var count = p.Value.Count;
            var currentIdx = 0;
            while (currentIdx < count)
            {
                result.Add(p.Value.Slice(currentIdx, size));
                currentIdx += size;
            }
        }
        return result;
    }
    public static TheoryData<int[], List<List<int>>> TestData => new()
    {
        {[3,3,3,3,3,1,3],[[5],[0,1,2],[3,4,6]]},
        {[2,1,3,3,3,2],[[1],[0,5],[2,3,4]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<List<int>> expected)
    {
        var actual = GroupThePeople(input);
        Assert.Equal(expected, actual);
    }
}
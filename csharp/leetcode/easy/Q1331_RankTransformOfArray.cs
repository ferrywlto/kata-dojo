class Q1331_RankTransformOfArray
{
    // TC: O(n log n), n log n for sort, n for getting the rank, n for writing result
    // SC: O(n), n to store the distinct ranks
    public int[] ArrayRankTransform(int[] arr)
    {
        if (arr.Length == 0) return arr;

        var set = arr.ToHashSet();
        var distinctArr = set.ToArray();
        Array.Sort(distinctArr);
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < distinctArr.Length; i++)
            dict.Add(distinctArr[i], i + 1);

        for (var j = 0; j < arr.Length; j++)
            arr[j] = dict[arr[j]];

        return arr;
    }
}
class Q1331_RankTransformOfArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{40,10,20,30}, new int[]{4,1,2,3}],
        [new int[]{100,100,100}, new int[]{1,1,1}],
        [new int[]{37,12,28,9,100,56,80,5,12}, new int[]{5,3,4,2,8,6,7,1,3}],
    ];
}
public class Q1331_RankTransformOfArrayTests
{
    [Theory]
    [ClassData(typeof(Q1331_RankTransformOfArrayTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1331_RankTransformOfArray();
        var actual = sut.ArrayRankTransform(input);
        Assert.Equal(expected, actual);
    }
}

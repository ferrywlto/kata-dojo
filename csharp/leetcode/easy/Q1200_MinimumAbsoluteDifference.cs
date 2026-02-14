class Q1200_MinimumAbsoluteDifference
{
    // TC: O(n log n), due to Array.Sort(), after the sort its O(n)
    // SC: O(n), n is the length of arr
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        // due to the fact that in a sorted array, diff between arr[i] and arr[i+1] must smaller than arr[i] and arr[i+2]
        // thus we only need to compare the diff of adjacent elements, also make the final result already sorted 
        Array.Sort(arr);
        // for bucket sorting
        var result = new Dictionary<int, IList<IList<int>>>();
        var minDiff = int.MaxValue;
        int diff;
        for (var i = 0; i < arr.Length - 1; i++)
        {
            diff = Math.Abs(arr[i + 1] - arr[i]);
            // no need to further process if the diff is not minimal
            if (diff <= minDiff)
            {
                minDiff = diff;
                if (result.TryGetValue(diff, out var list))
                {
                    list.Add([arr[i], arr[i + 1]]);
                }
                else
                {
                    result.Add(diff, [[arr[i], arr[i + 1]]]);
                }
            }
        }
        return result[minDiff];
    }
}
class Q1200_MinimumAbsoluteDifferenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{4,2,1,3}, new List<List<int>>{ new() {1, 2},new() {2, 3}, new() {3, 4}}],
        [new int[]{1,3,6,10,15}, new List<List<int>> { new() { 1, 3 } }],
        [new int[]{3,8,-10,23,19,-4,-14,27}, new List<List<int>> { new() { -14, -10 }, new() { 19, 23 }, new() { 23, 27 }}],
    ];
}

public class Q1200_MinimumAbsoluteDifferenceTests
{
    [Theory]
    [ClassData(typeof(Q1200_MinimumAbsoluteDifferenceTestData))]
    public void OfficialTestCases(int[] input, List<List<int>> expected)
    {
        var sut = new Q1200_MinimumAbsoluteDifference();
        var actual = sut.MinimumAbsDifference(input);
        Assert.Equal(expected, actual);
    }
}

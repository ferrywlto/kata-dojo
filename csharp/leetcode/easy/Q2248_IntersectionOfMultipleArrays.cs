public class Q2248_IntersectionOfMultipleArrays
{
    // TC: O(n), n scale with total number of items in nums
    // SC: O(m), m scale with unique numbers in nums
    public IList<int> Intersection(int[][] nums)
    {
        var sorted = new SortedDictionary<int, int>();
        foreach (var arr in nums)
        {
            foreach (var n in arr)
            {
                if (sorted.TryGetValue(n, out var val)) sorted[n] = ++val;

                else sorted.Add(n, 1);
            }
        }
        return sorted
            .Where(x => x.Value == nums.Length)
            .Select(x => x.Key)
            .ToList();
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [3,1,2,4,5],
                [1,2,3,4],
                [3,4,5,6],
            },
            new List<int> {3,4}
        ],
        [
            new int[][]
            {
                [1,2,3],
                [4,5,6],
            },
            new List<int> {}
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, List<int> expected)
    {
        var actual = Intersection(input);
        Assert.Equal(expected, actual);
    }
}
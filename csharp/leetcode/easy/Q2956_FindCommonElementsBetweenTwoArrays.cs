public class Q2956_FindCommonElementsBetweenTwoArrays
{
    // TC: O(n+m), n scale with length of nums1 plus length of nums2
    // SC: O(n+m), n scale with unique numbers in nums1, plus m scale with unique numbers in nums2
    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        var dict = new Dictionary<int, int>();
        foreach (var n in nums1)
        {
            if (dict.TryGetValue(n, out var val)) dict[n] = ++val;
            else dict.Add(n, 1);
        }

        var set = new HashSet<int>();
        var ans1 = 0;
        var ans2 = 0;

        foreach (var n in nums2)
        {
            if (dict.TryGetValue(n, out var value))
            {
                if (set.Add(n)) ans1 += value;
                ans2++;
            }
        }
        return [ans1, ans2];
    }
    public static TheoryData<int[], int[], int[]> TestData => new()
    {
        {[2,3,2], [1,2], [2,1]},
        {[4,3,2,3,1], [2,2,5,2,3,6], [3,4]},
        {[3,4,2,3], [1,5], [0,0]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int[] expected)
    {
        var actual = FindIntersectionValues(input1, input2);
        Assert.Equal(expected, actual);
    }
}

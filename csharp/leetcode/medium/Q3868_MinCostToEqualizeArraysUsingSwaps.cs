public class Q3868_MinCostToEqualizeArraysUsingSwaps
{
    // TC: O(n), n scale with length of nums1
    // SC: O(d), d scale with unique numbers in nums1 and nums2
    public int MinCost(int[] nums1, int[] nums2)
    {
        var freq1 = new Dictionary<int, int>();
        var freq2 = new Dictionary<int, int>();

        for (var i = 0; i < nums1.Length; i++)
        {
            var n1 = nums1[i];
            var n2 = nums2[i];

            if (freq1.TryGetValue(n1, out var value1))
                freq1[n1] = ++value1;
            else freq1.Add(n1, 1);

            if (!freq2.ContainsKey(n1)) freq2.Add(n1, 0);

            if (freq2.TryGetValue(n2, out var value2))
                freq2[n2] = ++value2;
            else freq2.Add(n2, 1);

            if (!freq1.ContainsKey(n2)) freq1.Add(n2, 0);
        }

        var sumOfDiff = 0;
        foreach (var pair in freq1)
        {
            var sum = pair.Value + freq2[pair.Key];
            if (sum % 2 == 1) return -1;

            var diff = Math.Abs(pair.Value - freq2[pair.Key]);
            sumOfDiff += diff;
        }

        // why divide 4 can refer to case [10, 10], [20, 20]:
        // diff of 10: 2
        // diff of 20: 2
        // no. of swap needed = 1
        return sumOfDiff / 4;
    }

    public static TheoryData<int[], int[], int> TestData => new()
    {
        { [10, 20], [20, 10], 0 }, { [10, 10], [20, 20], 1 }, { [10, 20], [30, 40], -1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums1, int[] nums2, int expected)
    {
        var actual = MinCost(nums1, nums2);
        Assert.Equal(expected, actual);
    }
}

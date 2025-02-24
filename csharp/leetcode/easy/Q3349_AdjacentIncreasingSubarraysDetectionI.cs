public class Q3349_AdjacentIncreasingSubarraysDetectionI
{
    // TC: O(n + m), n scale with length of nums, m scale with number of incresing segments found in nums
    // SC: O(m)
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        if (k == 1) return true;
        var start = 0;
        var dict = new List<Tuple<int, int>>();
        for (var i = 1; i < nums.Count; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                var len = i - start;
                if (len >= k)
                {
                    dict.Add(new(start, i - 1));
                }
                start = i;
            }
        }
        if (start != nums.Count - 1)
        {
            var len = nums.Count - start;
            if (len >= k)
            {
                dict.Add(new(start, nums.Count - 1));
            }
        }

        if (dict.Count == 0) return false;

        var firstLen = dict[0].Item2 - dict[0].Item1 + 1;
        if (firstLen / 2 >= k) return true;

        for (var i = 1; i < dict.Count; i++)
        {
            if (dict[i - 1].Item2 + 1 == dict[i].Item1) return true;

            var len = dict[i].Item2 - dict[i].Item1 + 1;
            if (len / 2 >= k) return true;
        }

        return false;
    }
    public static TheoryData<int[], int, bool> TestData => new()
    {
        {[2,5,7,8,9,2,3,4,3,1], 3, true},
        {[1,2,3,4,4,4,4,5,6,7], 5, false},
        {[1,2,3,4,4,4,4,5,6,7], 2, true},
        {[-15,19], 1, true},
        {[19,5], 1, true},
        {[-15,-13,4,7], 2, true},
        {[620,-371,-887,6,7,797,490,-652,-319,-705,582,-8,-332,-959,-565,347,880,286,191,196,203,206,937,941,944,946,-551,216,320], 4, true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, bool expected)
    {
        var actual = HasIncreasingSubarrays(input, k);
        Assert.Equal(expected, actual);
    }
}
public class Q697_DegreeOfArray
{
    // TC: O(n^2)
    // SC: O(n)
    public int FindShortestSubArray(int[] nums)
    {
        var analysis = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var degree = analysis.Max(x => x.Value);
        var mode = analysis.Where(x => x.Value == degree).ToList();
        var minLength = int.MaxValue;
        foreach(var m in mode)
        {
            var start = Array.IndexOf(nums, m.Key);
            var end = Array.LastIndexOf(nums, m.Key);
            var length = end - start + 1;
            if (length < minLength) minLength = length;
        }

        return minLength;
    }

    // TC: O(n)
    // SC: O(n)
    public int FindShortestSubArrayMoreEfficient(int[] nums)
    {
        var tracking = new Dictionary<int, (int firstIdx, int lastIdx, int count)>();
        for(var i=0; i<nums.Length; i++)
        {
            if (!tracking.TryGetValue(nums[i], out var value))
            {
                tracking.Add(nums[i], (i, i, 1));
            }
            else 
            {
                var tuple = tracking[nums[i]];
                tuple.lastIdx = i;
                tuple.count++;
                tracking[nums[i]] = tuple;
            }
        }
        var degree = tracking.Max(x => { return x.Value.count; });
        var mode = tracking.Where(x => x.Value.count == degree).ToList();
        var minLength = int.MaxValue;
        foreach(var m in mode)
        {
            var length = m.Value.lastIdx - m.Value.firstIdx + 1;
            if (length < minLength) minLength = length;
        }

        return minLength;
    }
}

public class Q697_DegreeOfArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1}, 1],
        [new int[]{1, 2, 2, 3, 1}, 2],
        [new int[]{1, 2, 2, 3, 1, 4, 2}, 6],
        [new int[]{1, 5, 2, 3, 5, 4, 5, 6}, 6],
    ];
}

public class Q697_DegreeOfArrayTests 
{
    [Theory]
    [ClassData(typeof(Q697_DegreeOfArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q697_DegreeOfArray();
        var actual = sut.FindShortestSubArrayMoreEfficient(input);
        Assert.Equal(expected, actual);
    }
}
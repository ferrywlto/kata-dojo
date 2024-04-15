public class Q219_ContainsDuplicateII
{
    /*
    Constraints:

    1 <= nums.length <= 105
    -109 <= nums[i] <= 109
    0 <= k <= 105
    */
    // TC:O(n), SC:O(n)
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                var lastIdx = dict[nums[i]];
                var diff = i - lastIdx;
                if (diff <= k) return true;
                else dict[nums[i]] = i;
            }
            else
            {
                dict.Add(nums[i], i);
            }
        }

        return false;
    }
}

public class Q219_ContainsDuplicateIITestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,2,3,1}, 3, true],
        [new int[]{1,0,1,1}, 1, true],
        [new int[]{1,2,3,1,2,3}, 2, false],
    ];
}

public class Q219_ContainsDuplicateIITests
{
    [Theory]
    [ClassData(typeof(Q219_ContainsDuplicateIITestData))]
    public void OfficialTestCases(int[] nums, int k, bool expected)
    {
        var sut = new Q219_ContainsDuplicateII();
        var actual = sut.ContainsNearbyDuplicate(nums, k);
        Assert.Equal(expected, actual);
    }
}
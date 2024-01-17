namespace dojo.leetcode;

public class Q219_ContainsDuplicateII
{
    /*
    Constraints:

    1 <= nums.length <= 105
    -109 <= nums[i] <= 109
    0 <= k <= 105
    */
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        // TC:O(n), SC:O(n)
        // dict<int, int>
        // key -> num[i], value -> last idx
        // if dict.ContainsKey(key)
        // if Math.abs(dict[key] - idx) <= k
        // return true
        // else 
        // return false
        //  else
        //  dict.Add(key, idx)
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

public class Q219_ContainsDuplicateIITests(ITestOutputHelper output): BaseTest(output)
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
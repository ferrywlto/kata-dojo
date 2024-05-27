class Q217_ContainsDuplicate
{
    // Inefficient way first
    // TC:O(n), SC:O(n)
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i]))
            {
                return true;
            }
            else
            {
                set.Add(nums[i]);
            }
        }

        return false;
    }

    // possible to have a SC:O(1) solution but have to exchange TC to O(n log n), which is not worth at this point.
    // The idea is to sort first, then check if next element is the same
}

class Q217_ContainsDuplicateTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,2,3,1}, true],
        [new int[]{1,2,3,4}, false],
        [new int[]{1,1,1,3,3,4,3,2,4,2}, true]
    ];
}

public class Q217_ContainsDuplicateTests
{
    [Theory]
    [ClassData(typeof(Q217_ContainsDuplicateTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q217_ContainsDuplicate();
        var actual = sut.ContainsDuplicate(input);
        Assert.Equal(expected, actual);
    }
}
public class Q1752_CheckIfArrayIsSortedAndRotated
{
    // TC: O(n), n sacle with length of nums
    // SC: O(1), space used does not sacle with input
    public bool Check(int[] nums)
    {
        var len = nums.Length;
        for (var i = 0; i < len - 1; i++)
        {
            if (nums[i + 1] < nums[i])
            {
                for (var j = i + 1; j < i + len; j++)
                {
                    if (nums[(j + 1) % len] < nums[j % len]) return false;
                }
                return true;
            }
        }
        return true;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[3,4,5,1,2], true},
        {[2,1,3,4], false},
        {[1,2,3], true},
        {[6,7,7,5], true},
        {[10,1,4,5,10], true},
        {[6,10,6], true},
        {[100,100,1,1,2,4,4,6,6,6,9,10,12,13,16,17,17,17,18,19,19,20,24,25,27,29,31,31,33,36,39,39,43,44,44,45,45,45,45,46,50,50,51,51,56,56,56,57,57,57,57,59,60,62,62,62,66,66,67,69,70,73,73,74,75,75,76,79,80,82,83,84,84,86,88,92,92,96,96,97,99,99], true},

    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = Check(input);
        Assert.Equal(expected, actual);
    }
}

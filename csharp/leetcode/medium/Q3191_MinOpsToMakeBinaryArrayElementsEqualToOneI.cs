public class Q3191_MinOpsToMakeBinaryArrayElementsEqualToOneI
{
    // TC: O(n), n sacle with length of nums, worst case 3n
    // SC: O(1), space used does not sacle with input
    public int MinOperations(int[] nums) {
        var oneCount = 0;
        var ops = 0;
        for(var i=0; i<nums.Length; i++)
        {
            if(nums[i] == 0)
            {
                if(i >= nums.Length - 2) return -1;
                for(var j=i; j<i+3; j++)
                {
                    if(nums[j] == 0) {
                        nums[j] = 1;
                        oneCount++;
                    }
                    else nums[j] = 0;
                }
                ops++;
            }
            else oneCount++;
        }
        return ops;
    }    
    public static TheoryData<int[], int> TestData => new ()
    {
        {[0,1,1,1,0,0], 3},
        {[0,1,1,1], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
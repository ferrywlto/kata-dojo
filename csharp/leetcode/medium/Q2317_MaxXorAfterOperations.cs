public class Q2317_MaxXorAfterOperations
{
    // The trick is if a bit is set to 1 at least once, take it.
    // The result is the number created by the bit positions that at least 1
    // If the bit position never set to 1, it remains 0
    // Which means, the OR of all numbers. 
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaximumXOR(int[] nums)
    {
        var result = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            result |= nums[i];
        }
        return result;
    }
    // This is to keep reference, the ops is just a confusion from the question. 
    // The Op is to turn bits off.
    // e.g. Op(3, 0) => 3 nothing change
    // Op(3, 1) => 2
    // Op(3, 2) => 1
    // Op(3, 3) => 0 
    // private int Op(int input, int x)
    // {
    //     return (input ^ x) & input;
    // }
    public static TheoryData<int[], int> TestData => new()
    {
        // 011
        // 010
        // 100
        // 110
        // --
        // 111
        { [3,2,4,6], 7},
        // 0001 
        // 0010
        // 0011
        // 1001
        // 0010
        // ---
        // 1011
        { [1,2,3,9,2], 11},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumXOR(input);
        Assert.Equal(expected, actual);
    }
}

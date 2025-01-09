public class Q2873_MaxValueOfOrderedTripletI
{
    // TC: O(n^3), n scale with length of nums, it have to be n^3 as we are calculating triplets
    // SC: O(1), space used does not scale with input
    public long MaximumTripletValue(int[] nums)
    {
        var result = 0L;
        for (var i = 0; i < nums.Length - 2; i++)
        {
            for (var j = i + 1; j < nums.Length - 1; j++)
            {
                for (var k = j + 1; k < nums.Length; k++)
                {
                    var val = TripletValue(nums[i], nums[j], nums[k]);
                    if (val > 0 && val > result) result = val;
                }
            }
        }
        return result;
    }
    private long TripletValue(long i, long j, long k) => (i - j) * k;

    public static TheoryData<int[], long> TestData => new()
    {
        {[12,6,1,2,7], 77},
        {[1,10,3,4,19], 133},
        {[1,2,3], 0},
        {[1000000,1,1000000], 999999000000},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, long expected)
    {
        var actual = MaximumTripletValue(input);
        Assert.Equal(expected, actual);
    }
}
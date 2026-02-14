public class Q2367_NumArithmeticTriplets
{
    // TC: O(n log n), n scale with length of nums, n times 2 log n with 2 binary search, thus n log n
    // SC: O(1), space used does not scale with input 
    public int ArithmeticTriplets(int[] nums, int diff)
    {
        var result = 0;
        for (var i = 0; i < nums.Length - 2; i++)
        {
            var searchLengthJ = nums.Length - i - 1;
            var targetJ = nums[i] + diff;
            var j = Array.BinarySearch(nums, i + 1, searchLengthJ, targetJ);
            if (j > i)
            {
                var searchLengthK = nums.Length - j - 1;
                var targetK = nums[j] + diff;
                var k = Array.BinarySearch(nums, j + 1, searchLengthK, targetK);

                if (k > j) result++;
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {0,1,4,6,7,10}, 3, 2],
        [new int[] {4,5,6,7,8,9}, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int diff, int expected)
    {
        var actual = ArithmeticTriplets(input, diff);
        Assert.Equal(expected, actual);
    }
}

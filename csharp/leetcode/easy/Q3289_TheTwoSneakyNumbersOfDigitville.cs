public class Q3289_TheTwoSneakyNumbersOfDigitville
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int[] GetSneakyNumbers(int[] nums)
    {
        var set = new HashSet<int>();
        var result = new int[2];
        var resultIdx = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (!set.Add(nums[i]))
            {
                result[resultIdx] = nums[i];
                resultIdx++;
                if (resultIdx == 2) return result;
            }
        }
        return result;
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[0,1,1,0], [0,1]},
        {[0,3,2,1,3,2], [2,3]},
        {[7,1,5,4,3,4,6,0,9,5,8,2], [4,5]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = GetSneakyNumbers(input);
        Array.Sort(actual);
        Assert.Equal(expected, actual);
    }
}

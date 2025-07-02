public class Q2294_PartitionArraySuchThatMaximumDifferenceIsK
{
    // TC: O(n log n), due to Array.Sort();
    // SC: O(m), m scale with unique numbers in nums
    public int PartitionArray(int[] nums, int k)
    {
        var arr = nums.ToHashSet().ToArray();
        Array.Sort(arr);

        var result = 1;
        var curr = arr[0];
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] - curr > k)
            {
                curr = arr[i];
                result++;
            }
        }
        return result;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,6,1,2,5], 2, 2},
        {[1,2,3], 1, 2},
        {[2,2,4,5], 0, 3},
        {[5,16,3,20,9,20,16,19,6], 4, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = PartitionArray(input, k);
        Assert.Equal(expected, actual);
    }
}
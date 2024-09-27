public class Q1979_FindGreatestCommonDivisorOfArray
{
    // TC: O(nlogn), due to Array.Sort()
    // SC: O(1), space used does not scale with nums 
    public int FindGCD(int[] nums)
    {
        Array.Sort(nums);
        if (nums[^1] % nums[0] == 0) 
            return nums[0];

        var largest = 1;
        for (var i = 2; i * i <= nums[0]; i++)
        {
            if (nums[0] % i == 0)
            {
                if (nums[^1] % i == 0 && i > largest)
                    largest = i;
                var residue = nums[0] / i;
                if (nums[^1] % residue == 0 && residue > largest)
                    largest = residue;
            }
        }
        return largest;
    }
    public static List<object[]> TestData =>
    [
        [new int[]{2,5,6,9,10}, 2],
        [new int[]{7,5,6,8,3}, 1],
        [new int[]{3,3}, 3],
        [new int[]{6,7,9}, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindGCD(input);
        Assert.Equal(expected, actual);
    }
}
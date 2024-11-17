public class Q2455_AvgValueOfEvenNumbersThatAreDivisibleByThree
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int AverageValue(int[] nums)
    {
        var sum = 0;
        var count = 0;
        foreach (var n in nums)
        {
            if (n % 6 == 0)
            {
                sum += n;
                count++;
            }
        }
        if (count == 0) return 0;
        return (int)Math.Floor((double)sum / count);
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,3,6,10,12,15}, 9],
        [new int[] {1,2,4,7,10}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = AverageValue(input);
        Assert.Equal(expected, actual);
    }
}
public class Q3895_CountDigitAppeasrances
{
    // TC: O(log n)
    // SC: O(1)
    public int CountDigitOccurrences(int[] nums, int digit)
    {
        var result = 0;
        foreach (var n in nums)
        {
            var curr = n;
            while (curr > 0)
            {
                if (curr % 10 == digit)
                    result++;
                curr /= 10;
            }
        }
        return result;
    }

    public static TheoryData<int[], int, int> TestData => new() { { [12, 54, 32, 22], 2, 4 }, { [1, 34, 7], 9, 0 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int digit, int expected)
    {
        var actual = CountDigitOccurrences(input, digit);
        Assert.Equal(expected, actual);
    }
}

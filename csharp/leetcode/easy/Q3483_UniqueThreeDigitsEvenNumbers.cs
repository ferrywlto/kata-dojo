public class Q3483_UniqueThreeDigitsEvenNumbers
{
    // TC: O(n^3), n scale with length of digits
    // SC: O(1), space used does not scale with input
    public int TotalNumbers(int[] digits)
    {
        var set = new HashSet<string>();
        for (var i = 0; i < digits.Length; i++)
        {
            if (digits[i] == 0) continue;
            for (var j = 0; j < digits.Length; j++)
            {
                if (j == i) continue;
                for (var k = 0; k < digits.Length; k++)
                {
                    if (k == i || k == j) continue;

                    if (digits[k] % 2 != 0) continue;
                    set.Add($"{digits[i]}{digits[j]}{digits[k]}");
                }
            }
        }
        return set.Count;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4], 12},
        {[0,2,2], 2},
        {[6,6,6], 1},
        {[1,3,5], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = TotalNumbers(input);
        Assert.Equal(expected, actual);
    }
}
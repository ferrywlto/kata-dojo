public class Q3663_FindTheLeastFrequentDigit
{
    // TC: O(log n), n scale with size of n
    // SC: O(1), space used does not scale with input.
    public int GetLeastFrequentDigit(int n)
    {
        var digitCount = new int[10];
        while (n > 0)
        {
            digitCount[n % 10]++;
            n /= 10;
        }

        var smallest = int.MaxValue;
        var idx = -1;
        for (var i = 0; i < digitCount.Length; i++)
        {
            if (digitCount[i] == 1) return i;
            else if (digitCount[i] < smallest && digitCount[i] != 0)
            {
                smallest = digitCount[i];
                idx = i;
            }
        }
        return idx;
    }

    public static TheoryData<int, int> TestData => new() { { 1553322, 1 }, { 723344511, 2 }, { 11, 1 } };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int expected)
    {
        var actual = GetLeastFrequentDigit(n);
        Assert.Equal(expected, actual);
    }
}

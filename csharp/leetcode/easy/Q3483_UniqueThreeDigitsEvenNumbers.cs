public class Q3483_UniqueThreeDigitsEvenNumbers
{
    // TC: O(n^3), n scale with length of digits
    // SC: O(1), space used does not scale with input
    public int TotalNumbers(int[] digits)
    {
        var freq = new int[10];
        foreach (var d in digits)
        {
            freq[d]++;
        }
        var result = 0;

        for (var num = 100; num < 1000; num++)
        {
            if (num % 2 != 0) continue;  // only even numbers

            // Decompose the number into hundreds, tens, and ones digits
            var a = num / 100;
            var b = num / 10 % 10;
            var c = num % 10;

            // Build candidate frequency
            var candidateFreq = new int[10];
            candidateFreq[a]++;
            candidateFreq[b]++;
            candidateFreq[c]++;

            var canForm = true;
            for (var d = 0; d < 10; d++)
            {
                if (candidateFreq[d] > freq[d])
                {
                    canForm = false;
                    break;
                }
            }
            if (canForm) result++;
        }
        return result;
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

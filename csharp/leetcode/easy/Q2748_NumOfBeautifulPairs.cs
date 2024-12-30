public class Q2748_NumOfBeautifulPairs
{
    // TC: O(n^2), the pre-calculation time is O(1), the nested loop to find pairs is O(n^2)
    // SC: O(1), the coprime hashset space is fixed, no other space used
    public int CountBeautifulPairs(int[] nums)
    {
        // Pre-calculate the coprimes
        var coprimes = new HashSet<(int, int)>();
        for (var i = 1; i < 10; i++)
        {
            for (var j = i; j < 10; j++)
            {
                if (GCD(i, j) == 1) coprimes.Add((i, j));
            }
        }
        var result = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                var firstDigit = FirstDigit(nums[i]);
                var secondDigit = nums[j] % 10;
                if (
                    coprimes.Contains((firstDigit, secondDigit)) ||
                    coprimes.Contains((secondDigit, firstDigit))
                 ) result++;
            }
        }
        return result;
    }
    private int FirstDigit(int input)
    {
        while (input >= 10)
        {
            input /= 10;
        }
        return input;
    }
    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[2,5,1,4], 5},
        {[11,21,12], 2},
        {[756,1324,2419,495,106,111,1649,1474,2001,1633,273,1804,2102,1782,705,1529,1761,1613,111,186,412], 183},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountBeautifulPairs(input);
        Assert.Equal(expected, actual);
    }

}
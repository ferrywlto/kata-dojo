public class Q2275_LargestCombinationWithBitwiseAndGreaterThanZero(ITestOutputHelper output)
{
    public int LargestCombination(int[] candidates)
    {
        var len = candidates.Length;
        // set bits for all combination
        var bits = 1;
        for (var i = 0; i < len; i++) bits *= 2;
        // -1 since 4 = 100, we need to start with greedy set size 011
        bits -= 1;
        while (bits > 0)
        {
            var tmp = bits;
            var andResult = 0;
            var countOfOne = 0;
            var candIdx = len - 1;
            var list = new List<int>();
            var init = false;
            while (tmp > 0)
            {
                if ((tmp & 1) == 1)
                {
                    countOfOne++;
                    list.Add(candIdx);
                    if (init)
                    {
                        andResult &= candidates[candIdx];
                    }
                    else
                    {
                        andResult = candidates[candIdx];
                        init = true;
                    }
                }
                candIdx--;
                tmp >>= 1;
            }
            output.WriteLine("bits: {0}, idx:{1}, andResult: {2}", bits, string.Join(',', list), andResult);
            if (andResult > 0) return countOfOne;
            bits--; 
        }

        Console.WriteLine(bits);
        return 0;
    }



    public static TheoryData<int[], int> TestData => new()
    {
        {[16,17,71,62,12,24,14], 4},
        {[8,8], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = LargestCombination(input);
        Assert.Equal(expected, actual);
    }
}

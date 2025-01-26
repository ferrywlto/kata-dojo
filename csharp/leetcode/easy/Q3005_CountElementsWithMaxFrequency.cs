public class Q3005_CountElementsWithMaxFrequency
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique numbers in nums
    public int MaxFrequencyElements(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        var highestFreq = 0;
        foreach (var n in nums)
        {
            if (dict.TryGetValue(n, out var val))
            {
                dict[n] = ++val;
                if (val > highestFreq)
                {
                    highestFreq = val;
                }
            }
            else
            {
                dict.Add(n, 1);
                if (1 > highestFreq)
                {
                    highestFreq = 1;
                }
            }
        }
        var result = 0;
        foreach (var p in dict)
        {
            if (p.Value == highestFreq)
            {
                result += p.Value;
            }
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,2,3,1,4], 4},
        {[1,2,3,4,5], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxFrequencyElements(input);
        Assert.Equal(expected, actual);
    }
}
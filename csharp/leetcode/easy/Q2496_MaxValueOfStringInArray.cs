public class Q2496_MaxValueOfStringInArray
{
    // TC: O(n), n scale with total characters in strs
    // SC: O(1), space used does not scale with input
    public int MaximumValue(string[] strs)
    {
        var max = int.MinValue;
        foreach (var s in strs)
        {
            if (int.TryParse(s, out var val))
            {
                if (val > max) max = val;
            }
            else
            {
                if (s.Length > max) max = s.Length;
            }
        }
        return max;
    }
    public static List<object[]> TestData =>
    [
        [new string[] {"alic3","bob","3","4","00000"}, 5],
        [new string[] {"1","01","001","0001"}, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = MaximumValue(input);
        Assert.Equal(expected, actual);
    }
}
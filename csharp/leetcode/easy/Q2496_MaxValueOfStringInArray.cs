public class Q2496_MaxValueOfStringInArray
{
    public int MaximumValue(string[] strs)
    {
        return 0;
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
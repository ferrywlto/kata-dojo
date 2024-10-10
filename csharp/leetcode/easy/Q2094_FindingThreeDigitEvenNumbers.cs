public class Q2094_FindingThreeDigitEvenNumbers
{
    public int[] FindEvenNumbers(int[] digits) 
    {
        return [];    
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,1,3,0}, new int[] {102,120,130,132,210,230,302,310,312,320}],
        [new int[] {2,2,8,8,2}, new int[] {222,228,282,288,822,828,882}],
        [new int[] {3,7,5}, Array.Empty<int>()],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = FindEvenNumbers(input);
        Assert.Equal(expected, actual);
    }
}
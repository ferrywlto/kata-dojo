public class Q2553_SeparateDigitsInArray
{
    public int[] SeparateDigits(int[] nums)
    {
        return [];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {13,25,83,77}, new int[] {1,3,2,5,8,3,7,7}],
        [new int[] {7,1,3,9}, new int[] {7,1,3,9}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = SeparateDigits(input);
        Assert.Equal(expected, actual);
    }
}
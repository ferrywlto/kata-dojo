public class Q2148_CountElementsWithStrictlySmallerAndGreaterElements
{
    public int CountElements(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {11,7,2,15}, 2],
        [new int[] {-3,3,3,90}, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountElements(input);
        Assert.Equal(expected, actual);
    }
}
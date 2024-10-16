public class Q2154_KeepMultiplyingFoundValuesByTwo
{
    public int FindFinalValue(int[] nums, int original)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {5,3,6,1,12}, 3, 24],
        [new int[] {2,7,9}, 4, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int original, int expected)
    {
        var actual = FindFinalValue(input, original);
        Assert.Equal(expected, actual);
    }
}
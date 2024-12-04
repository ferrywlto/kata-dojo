public class Q2562_FindArrayConcatenationValue
{
    public long FindTheArrayConcVal(int[] nums)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {7,52,2,4}, 596],
        [new int[] {5,14,13,8,12}, 673],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = FindTheArrayConcVal(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2119_NumberAfterDoubleReversal
{
    public bool IsSameAfterReversals(int num)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [526, true],
        [1800, false],
        [0, true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = IsSameAfterReversals(input);
        Assert.Equal(expected, actual);
    }
}
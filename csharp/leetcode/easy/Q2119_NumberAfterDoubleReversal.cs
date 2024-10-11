public class Q2119_NumberAfterDoubleReversal
{
    // TC: O(1) obviously
    // SC: O(1) obviously
    public bool IsSameAfterReversals(int num)
    {
        if (num < 10) return true;

        return num % 10 != 0;
    }
    public static List<object[]> TestData =>
    [
        [526, true],
        [1800, false],
        [0, true],
        [10, false],
        [12, true],
        [110, false],
        [111, true],
        [101, true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, bool expected)
    {
        var actual = IsSameAfterReversals(input);
        Assert.Equal(expected, actual);
    }
}
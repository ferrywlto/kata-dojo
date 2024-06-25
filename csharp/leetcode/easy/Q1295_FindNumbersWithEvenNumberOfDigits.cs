class Q1295_FindNumbersWithEvenNumberOfDigits
{
    public int FindNumbers(int[] nums)
    {
        return 0;
    }
}
class Q1295_FindNumbersWithEvenNumberOfDigitsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {12,345,2,6,7896}, 2],
        [new int[] {555,901,482,1771}, 1],
    ];
}
public class Q1295_FindNumbersWithEvenNumberOfDigitsTests
{
    [Theory]
    [ClassData(typeof(Q1295_FindNumbersWithEvenNumberOfDigitsTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1295_FindNumbersWithEvenNumberOfDigits();
        var actual = sut.FindNumbers(input);
        Assert.Equal(expected, actual);
    }
}
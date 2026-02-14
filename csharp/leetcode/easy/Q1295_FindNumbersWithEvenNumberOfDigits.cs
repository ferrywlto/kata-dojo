class Q1295_FindNumbersWithEvenNumberOfDigits
{
    // TC: O(n), n is length of nums * how large is each number
    // SC: O(1), no space used for operations
    public int FindNumbers(int[] nums)
    {
        var result = 0;
        foreach (var n in nums)
        {
            if (n == 0) continue;
            var temp = n;
            var digits = 0;
            while (temp > 0)
            {
                temp /= 10;
                digits++;
            }
            if (digits % 2 == 0) result++;
        }
        return result;
    }
}
class Q1295_FindNumbersWithEvenNumberOfDigitsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {0,345,2,7896}, 1],
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

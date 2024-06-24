class Q1287_ElementAppearingMoreThan25PercentInSortedArray
{
    public int FindSpecialInteger(int[] arr)
    {
        return 0;
    }
}
class Q1287_ElementAppearingMoreThan25PercentInSortedArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,2,6,6,6,6,7,10}, 6],
        [new int[] {1,1}, 1],
    ];
}
public class Q1287_ElementAppearingMoreThan25PercentInSortedArrayTests
{
    [Theory]
    [ClassData(typeof(Q1287_ElementAppearingMoreThan25PercentInSortedArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1287_ElementAppearingMoreThan25PercentInSortedArray();
        var actual = sut.FindSpecialInteger(input);
        Assert.Equal(expected, actual);
    }
}
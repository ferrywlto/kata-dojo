class Q1299_ReplaceElementsWithGreatestElementOnRightSide
{
    public int[] ReplaceElements(int[] arr)
    {
        return [];
    }
}
class Q1299_ReplaceElementsWithGreatestElementOnRightSideTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {17, 18, 5, 4, 6, 1}, new int[] {18, 6, 6, 6, 1, -1}],
        [new int[] {400}, new int[] {-1}],
    ];
}
public class Q1299_ReplaceElementsWithGreatestElementOnRightSideTests
{
    [Theory]
    [ClassData(typeof(Q1299_ReplaceElementsWithGreatestElementOnRightSideTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1299_ReplaceElementsWithGreatestElementOnRightSide();
        var actual = sut.ReplaceElements(input);
        Assert.Equal(expected, actual);
    }
}

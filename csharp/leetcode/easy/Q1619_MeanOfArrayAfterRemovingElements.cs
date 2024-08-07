class Q1619_MeanOfArrayAfterRemovingElements
{
    public double TrimMean(int[] arr)
    {
        return 0;
    }
}
class Q1619_MeanOfArrayAfterRemovingElementsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3}, 2.0],
        [new int[] {6,2,7,5,1,2,0,3,10,2,5,0,5,5,0,8,7,6,8,0}, 4.0],
        [new int[] {6,0,7,0,7,5,7,8,3,4,0,7,8,1,6,8,1,1,2,4,8,1,9,5,4,3,8,5,10,8,6,6,1,0,6,10,8,2,3,4}, 4.77778],
    ];
}
public class Q1619_MeanOfArrayAfterRemovingElementsTests
{
    [Theory]
    [ClassData(typeof(Q1619_MeanOfArrayAfterRemovingElementsTestData))]
    public void OfficialTestCases(int[] input, double expected)
    {
        var sut = new Q1619_MeanOfArrayAfterRemovingElements();
        var actual = sut.TrimMean(input);
        Assert.Equal(expected, actual);
    }
}
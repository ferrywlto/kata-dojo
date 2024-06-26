class Q1299_ReplaceElementsWithGreatestElementOnRightSide
{
    // TC: O(n), n is length of arr
    // SC: O(1), no space used in operations
    public int[] ReplaceElements(int[] arr)
    {
        var currentMax = arr[^1];
        for(var i = arr.Length - 2; i>=0; i--)
        {
            var temp = arr[i];
            arr[i] = currentMax;
            currentMax = Math.Max(temp, currentMax);            
        }
        arr[^1] = -1;
        return arr;
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

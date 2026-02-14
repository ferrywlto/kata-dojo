class Q1287_ElementAppearingMoreThan25PercentInSortedArray
{
    // TC: O(n), n is length of arr
    // SC: O(1), no space used in operations
    public int FindSpecialInteger(int[] arr)
    {
        if (arr.Length == 1) return arr[0];

        double thresold = arr.Length / 4;
        var current = arr[0];
        var idx = 0;
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] != current)
            {
                if (i - idx > thresold) return arr[i - 1];
                current = arr[i];
                idx = i;
            }
        }
        return arr[^1];
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

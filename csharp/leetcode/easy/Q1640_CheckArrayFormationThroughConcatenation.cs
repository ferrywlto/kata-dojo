class Q1640_CheckArrayFormationThroughConcatenation
{
    // TC: O(n+m), where n is the size of arr plus total elements in pieces, in worst case n+m when all arrays is in 1 size and can form arr
    // SC: O(m), where m is number of pieces stored in dict
    public bool CanFormArray(int[] arr, int[][] pieces)
    {
        var dict = pieces.ToDictionary(x => x[0], x => x);
        for (var i = 0; i < arr.Length; i++)
        {
            if (dict.TryGetValue(arr[i], out var value))
            {
                for (var j = 0; j < value.Length; j++)
                {
                    if (arr[i + j] != value[j]) return false;
                }
                i += value.Length - 1;
            }
            else return false;
        }
        return true;
    }
}
class Q1640_CheckArrayFormationThroughConcatenationTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {15,88}, new int[][] {[88],[15]}, true],
        [new int[] {49,18,16}, new int[][] {[16,18,49]}, false],
        [new int[] {91,4,64,78}, new int[][] {[78],[4,64],[91]}, true],
    ];
}
public class Q1640_CheckArrayFormationThroughConcatenationTests
{
    [Theory]
    [ClassData(typeof(Q1640_CheckArrayFormationThroughConcatenationTestData))]
    public void OfficialTestCases(int[] input, int[][] pieces, bool expected)
    {
        var sut = new Q1640_CheckArrayFormationThroughConcatenation();
        var actual = sut.CanFormArray(input, pieces);
        Assert.Equal(expected, actual);
    }
}

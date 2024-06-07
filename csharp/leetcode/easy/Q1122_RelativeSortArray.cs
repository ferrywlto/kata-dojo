
class Q1122_RelativeSortArray
{
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        return [];
    }
}
class Q1122_RelativeSortArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[] {2,3,1,3,2,4,6,7,9,2,19},
            new int[] {2,1,4,3,9,6},
            new int[] {2,2,2,1,4,3,3,9,6,7,19},
        ],
        [
            new int[] {28,6,22,8,44,17},
            new int[] {22,28,8,6},
            new int[] {22,28,8,6,17,44},
        ]
    ];
}
public class Q1122_RelativeSortArrayTests
{
    [Theory]
    [ClassData(typeof(Q1122_RelativeSortArrayTestData))]
    public void OfficialTestCases(int[] arr1, int[] arr2, int[] expected)
    {
        var sut = new Q1122_RelativeSortArray();
        var actual = sut.RelativeSortArray(arr1, arr2);
        Assert.Equal(expected, actual);
    }
}

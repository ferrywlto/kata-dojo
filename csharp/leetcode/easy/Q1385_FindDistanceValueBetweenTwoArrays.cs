class Q1385_FindDistanceValueBetweenTwoArrays
{
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        return 0;
    }
}
class Q1385_FindDistanceValueBetweenTwoArraysTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {4,5,8}, new int[] {10,9,1,8}, 2, 2],
        [new int[] {1,4,2,3}, new int[] {-4,-3,6,10,20,30}, 3, 2],
        [new int[] {2,1,100,3}, new int[] {-5,-2,10,-3,7}, 6, 1],
    ];
}
public class Q1385_FindDistanceValueBetweenTwoArraysTests
{
    [Theory]
    [ClassData(typeof(Q1385_FindDistanceValueBetweenTwoArraysTestData))]
    public void OfficialTestCases(int[] input1, int[] input2, int d, int expected)
    {
        var sut = new Q1385_FindDistanceValueBetweenTwoArrays();
        var actual = sut.FindTheDistanceValue(input1, input2, d);
        Assert.Equal(expected, actual);
    }
}
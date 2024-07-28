class Q1534_CountGoodTriplets
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        return 0;
    }
}
class Q1534_CountGoodTripletsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {3,0,1,1,9,7}, 7, 2, 3, 4],
        [new int[] {1,1,2,2,3}, 0, 0, 1, 0],
    ];
}
public class Q1534_CountGoodTripletsTests
{
    [Theory]
    [ClassData(typeof(Q1534_CountGoodTripletsTestData))]
    public void OfficialTestCases(int[] input, int i, int j, int k, int expected)
    {
        var sut = new Q1534_CountGoodTriplets();
        var actual = sut.CountGoodTriplets(input, i, j, k);
        Assert.Equal(expected, actual);
    }
}

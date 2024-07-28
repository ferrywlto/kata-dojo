class Q1534_CountGoodTriplets
{
    // TC: O(n^3), where n is length of arr -3
    // SC: O(1), the space used is fixed
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        var result = 0;
        for(var i=0; i<arr.Length-2; i++)
        {
            for(var j=i+1; j<arr.Length-1; j++)
            {
                for(var k=j+1; k<arr.Length; k++)
                {
                    if (
                        Math.Abs(arr[j] - arr[i]) <= a &&
                        Math.Abs(arr[j] - arr[k]) <= b &&
                        Math.Abs(arr[k] - arr[i]) <= c
                    ) result++;
                }
            }
        }
        return result;
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


class Q1380_LuckyNumberInMatrix
{
    public IList<int> LuckyNumbers (int[][] matrix) 
    {
        return [];    
    }    
}
class Q1380_LuckyNumberInMatrixTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int[][] {
                [3,7,8],[9,11,13],[15,16,17]
            },
            new int[] {15}
        ],
        [
            new int[][] {
                [1,10,4,2],[9,3,8,7],[15,16,17,12]
            },
            new int[] {12}
        ],
        [
            new int[][] {
                [7,8],[1,2]
            },
            new int[] {7}
        ],        
    ];
}
public class Q1380_LuckyNumberInMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1380_LuckyNumberInMatrixTestData))]
    public void OfficialTestCases(int[][] input, int[] expected)
    {
        var sut = new Q1380_LuckyNumberInMatrix();
        var actual = sut.LuckyNumbers(input);
        Assert.Equal(expected, actual);
    }
}
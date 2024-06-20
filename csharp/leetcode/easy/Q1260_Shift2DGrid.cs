class Q1260_Shift2DGrid
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        return [];
    }
}
class Q1260_Shift2DGridTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            { 
                [1,2,3],
                [4,5,6],
                [7,8,9] 
            }, 1, 
            new List<List<int>> 
            { 
                new() { 9, 1, 2 }, 
                new() { 3, 4, 5 },
                new() { 6, 7, 8 }
            }
        ],
        [
            new int[][]
            { 
                [3,8,1,9],
                [19,7,2,5],
                [4,6,11,10],
                [12,0,21,13] 
            }, 4, 
            new List<List<int>> 
            { 
                new() { 12, 0, 21, 13 }, 
                new() { 3, 8, 1, 9 },
                new() { 19, 7, 2, 5 }, 
                new() { 4, 6, 11, 10 },
            }            
        ],
        [
            new int[][]
            { 
                [1,2,3],
                [4,5,6],
                [7,8,9] 
            }, 9, 
            new List<List<int>> 
            { 
                new() { 1, 2, 3 }, 
                new() { 4, 5, 6 },
                new() { 7, 8, 9 }, 
            }            
        ],
    ];
}
public class Q1260_Shift2DGridTests
{
    [Theory]
    [ClassData(typeof(Q1260_Shift2DGridTestData))]
    public void OfficialTestCases(int[][] input, int times, IList<IList<int>> expected)
    {
        var sut = new Q1260_Shift2DGrid();
        var actual = sut.ShiftGrid(input, times);
        Assert.Equal(expected, actual);
    }
}
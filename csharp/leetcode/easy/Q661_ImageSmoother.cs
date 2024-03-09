namespace dojo.leetcode;

public class Q661_ImageSmoother
{
    public int[][] HandleSingleRow(int[][] input)
    {
        var row = input[0];
        var result = new int[row.Length];
        var lastKnown = row[0] + row[1];
        result[0] = lastKnown / 2;
        
        for (var i=1; i<row.Length; i++) 
        {
            if(i == row.Length - 1)
            {
                result[i] = lastKnown / 2;
            }
            else
            {
                result[i] = (lastKnown + row[i + 1])/3;
                lastKnown = row[i] + row[i + 1];
            }
        }
        return [result];
    }

    // TODO: Resume afterwards
    // public int[][] HandleTwoRows(int[][] input)
    // {
    //     var results = new int[input.Length][];

    //     for(var i=0; i<input.Length; i++)
    //     {
    //         var row = input[i];
    //         results[i] = new int[]();
    //         var lastKnown = row[0] + row[1];
    //         result[0] = lastKnown / 2;
            
    //         for (var j=1; j<row.Length; j++) 
    //         {
    //             if(j == row.Length - 1)
    //             {
    //                 result[j] = lastKnown / 2;
    //             }
    //             else
    //             {
    //                 result[j] = (lastKnown + row[j + 1])/3;
    //                 lastKnown = row[j] + row[j + 1];
    //             }
    //         }
    //     } 
    //     return [result];
    // }

    // TC: O(n^2)
    // SC: O(n)
    public int[][] ImageSmoother(int[][] img)
    {
        // handle single cell
        if (img.Length == 0 || img[0].Length == 0) return [[0]];
        if (img.Length == 1 && img[0].Length == 1) return [[1]];
        // handle single row
        // if (img.Length == 1) return HandleSingleRow(img);
        // if (img.Length == 2) return HandleTwoRows(img);

        var result = new int[img.Length][];
        for(var n=0; n<result.Length; n++)
        {
            result[n] = new int[img[0].Length];
        };

        for(var row=0; row<img.Length; row++) 
        {
            for(var col=0; col<img[row].Length; col++) 
            {
                var list = GetSurroundCells(img, row, col);
                var sum = img[row][col];
                foreach (var (new_row, new_col) in list) 
                    sum += img[new_row][new_col];
                result[row][col] = sum / (list.Count+1);
            }
        }

        return result;
    }

    public void nothing(int[][] input, int row, int col)
    {
        // divide and conquer
        // handle 1 cell only input
        // handle 1 row only input
        // handle 2 row only input
        // handle N rows input
        // 0,0 is special that need to store and calculate once
        // then use 0,0 to calculate the first 2 rows 
        // store known for later use
        var lastKnownTopRow =
            input[row][col] +
            input[row][col + 1] +
            input[row + 1][col] +
            input[row + 1][col + 1];

        var currentTopRow = 
            input[row][col + 1] +
            input[row + 1][col + 1];

        var resultTopRow = lastKnownTopRow + currentTopRow;

        var lastKnownBottomRow =
            input[row][col] +
            input[row][col + 1] +
            input[row - 1][col] +
            input[row - 1][col + 1];
        
        var currentBottomRow =
            input[row][col + 1] +
            input[row - 1][col + 1];

        var resultBottomRow = lastKnownBottomRow + currentBottomRow;

        var lastKnownMiddleRow =
            input[row - 1][col] +
            input[row - 1][col + 1] +
            input[row][col] +
            input[row][col + 1] +
            input[row + 1][col] +
            input[row + 1][col + 1];

        var currentMiddleRow = 
            input[row][col + 1] +
            input[row - 1][col + 1] +
            input[row + 1][col + 1];

        var sum = input[row][col];
        if(row == 0 && row + 1 < input.Length)
        {
            sum += input[row + 1][col];
        }
        if(row + 1 < input.Length)
        {

        }
    }

    public List<(int row, int col)> GetSurroundCells(int[][] input, int row, int col)
    {
        var list = new List<(int row, int col)>();
        var left = col - 1;
        var right = col + 1;
        var hasLeft = left >= 0;
        var hasRight = right < input[0].Length;
        var top = row - 1;
        var bottom = row + 1;
        var hasTop = top >= 0;
        var hasBottom = bottom < input.Length;
        
        if (hasLeft)
        {
            list.Add((row, left));
            if(hasTop) list.Add((top, left));
            if(hasBottom) list.Add((bottom, left)); 
        } 
        if (hasRight)
        {
            list.Add((row, right));
            if(hasTop) list.Add((top, right));
            if(hasBottom) list.Add((bottom, right)); 
        }
        if(hasTop) list.Add((top, col));
        if(hasBottom) list.Add((bottom, col));

        return list;
    }
}

public class Q661_ImageSmootherTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][] { [1, 1, 1], [1, 0, 1], [1, 1, 1] },
            new int[][] { [0, 0, 0], [0, 0, 0], [0, 0, 0] }
        ],
        [
            new int[][] { [100,200,100],[200,50,200],[100,200,100] },
            new int[][] { [137,141,137],[141,138,141],[137,141,137] }
        ],
    ];
}

public class Q661_ImageSmootherTests
{
    [Theory]
    [ClassData(typeof(Q661_ImageSmootherTestData))]
    public void OfficialTestCases(int[][] input, int[][] expected)
    {
        var sut = new Q661_ImageSmoother();
        var actual = sut.ImageSmoother(input);
        // var expectedLines = expected.Select(row => $"[{string.Join(',', row)}]");
        // Console.WriteLine($"expected: {string.Join(',', expectedLines)}");
        // var actualLines = actual.Select(row => $"[{string.Join(',', row)}]");
        // Console.WriteLine($"actual: {string.Join(',', actualLines)}");
        Assert.True(AreEqual2D(expected, actual));
    }

    public bool AreEqual2D(int[][] expected, int[][] actual)
    {
        if (actual.Length != expected.Length) 
            return false;

        for(var i = 0; i<actual.Length; i++)
        {
            if (!Enumerable.SequenceEqual(expected[i], actual[i])) 
                return false;
        }

        return true;
    }
}
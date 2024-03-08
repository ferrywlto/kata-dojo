namespace dojo.leetcode;

public class Q661_ImageSmoother
{
    // TC: O(n^2)
    // SC: O(n)
    public int[][] ImageSmoother(int[][] img)
    {
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
        // [
        //     new int[][] { [1, 1, 1], [1, 0, 1], [1, 1, 1] },
        //     new int[][] { [0, 0, 0], [0, 0, 0], [0, 0, 0] }
        // ],
        // [
        //     new int[][] { [100,200,100],[200,50,200],[100,200,100] },
        //     new int[][] { [137,141,137],[141,138,141],[137,141,137] }
        // ],
        [
            new int[][] { [2,3,4],[5,6,7],[8,9,10],[11,12,13],[14,15,16] },
            new int[][] { [2,3,4],[5,6,7],[8,9,10],[11,12,13],[14,15,16] }
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
        var expectedLines = expected.Select(row => $"[{string.Join(',', row)}]");
        Console.WriteLine($"expected: {string.Join(',', expectedLines)}");
        var actualLines = actual.Select(row => $"[{string.Join(',', row)}]");
        Console.WriteLine($"actual: {string.Join(',', actualLines)}");
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
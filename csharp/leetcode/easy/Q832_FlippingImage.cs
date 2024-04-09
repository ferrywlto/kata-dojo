
namespace dojo.leetcode;

public class Q832_FlippingImage
{
    // TC: O(n), n is total items in matrix
    // SC: O(1), no extra memory used
    public int[][] FlipAndInvertImage(int[][] image)
    {
        // since this is a n x n matrix, only need to find the row size at fisrt row
        var rowWidth = image[0].Length / 2;
        for(var row=0; row<image.Length; row++)
        {
            for(var col=0; col<rowWidth; col++)
            {
                // Console.WriteLine($"row: {row}, col: {col}");
                var colIdx = col + 1;
                var temp = image[row][col];
                image[row][col] = image[row][^colIdx];
                image[row][^colIdx] = temp;

                if (image[row][col] == 0) image[row][col] = 1;
                else image[row][col] = 0;

                if (image[row][^colIdx] == 0) image[row][^colIdx] = 1;
                else image[row][^colIdx] = 0; 
            }
            // invert middle item if rowWidth is odd
            if(image[0].Length % 2 == 1)
            {
                if (image[row][rowWidth] == 0) image[row][rowWidth] = 1;
                else image[row][rowWidth] = 0;
            }
        }
        return image;
    }
}

public class Q832_FlippingImageTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][] {
                [1,1,0],
                [1,0,1],
                [0,0,0]
            },
            new int[][] {
                [1,0,0],
                [0,1,0],
                [1,1,1]
            }
        ],
        [
            new int[][] {
                [1,1,0,0],
                [1,0,0,1],
                [0,1,1,1],
                [1,0,1,0]
            },
            new int[][] {
                [1,1,0,0],
                [0,1,1,0],
                [0,0,0,1],
                [1,0,1,0]
            }
        ],
    ];
}

public class Q832_FlippingImageTests
{
    [Theory]
    [ClassData(typeof(Q832_FlippingImageTestData))]
    public void OfficialTestCases(int[][] input, int[][] expected)
    {
        var sut = new Q832_FlippingImage();
        var actual = sut.FlipAndInvertImage(input);
        Assert.Equal(expected, actual);
    }
}
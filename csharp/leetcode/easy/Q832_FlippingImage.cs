
namespace dojo.leetcode;

public class Q832_FlippingImage
{
    public int[][] FlipAndInvertImage(int[][] image) 
    {
        return [];    
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
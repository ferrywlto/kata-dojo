
namespace dojo.leetcode;

public class Q605_CanPlaceFlowers
{
    // Siliding window, 1 pass
    public bool CanPlaceFlowers(int[] flowerbed, int n) 
    {
        if (n == 0) return true;
        if (flowerbed.Length == 1)
        {
            if (n > 1) return false;
            else if (n == 1) return flowerbed[0] == 0;
        }
        else if (flowerbed.Length == 2)
        {
            if (n > 1) return false;
            else if (n == 1) return flowerbed[0] == 0 && flowerbed[1] == 0;
        }

        for(var i=0; i<flowerbed.Length; i++)
        {
            // special case for start and end
            if(i == 0)
            {
                if (flowerbed[0] == 0 && flowerbed[1] == 0)
                {
                    flowerbed[0] = 1;
                    n--;
                }
            }
            else if(i == flowerbed.Length - 1)
            {
                if (flowerbed[^1] == 0 && flowerbed[^2] == 0)
                {
                    flowerbed[^1] = 1;
                    n--;
                }
            }
            else if(flowerbed[i] == 0 && flowerbed[i-1] == 0 && flowerbed[i+1] == 0)
            {
                flowerbed[i] = 1;
                n--;
            }
            if (n == 0) return true;
        }
        return n == 0;   
    }
}

public class Q605_CanPlaceFlowersTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0}, 1, true],
        [new int[]{0}, 2, false],
        [new int[]{1}, 1, false],
        [new int[]{0,0}, 1, true],
        [new int[]{0,0}, 2, false],
        [new int[]{1,0}, 1, false],
        [new int[]{0,1}, 1, false],
        [new int[]{0,0,0}, 1, true],
        [new int[]{0,0,0}, 2, true],
        [new int[]{0,1,0}, 1, false],
        [new int[]{1,0,0}, 1, true],
        [new int[]{1,0,0}, 2, false],
        [new int[]{1,0,0,0,1}, 1, true],
        [new int[]{1,0,0,0,1}, 2, false],
        [new int[]{0,0,0,0,0,1,0,0}, 0, true],
    ];
}


public class Q605_CanPlaceFlowersTests
{
    [Theory]
    [ClassData(typeof(Q605_CanPlaceFlowersTestData))]
    public void OfficialTestCases(int[] input, int pots, bool expected)
    {
        var sut = new Q605_CanPlaceFlowers();
        var actual = sut.CanPlaceFlowers(input, pots);
        Assert.Equal(expected, actual);
    }
}
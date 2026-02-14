class Q605_CanPlaceFlowers
{
    // Siliding window, 1 pass
    // TC: O(n)
    // SC: O(1)
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int i = 0, count = 0;
        while (i < flowerbed.Length)
        {
            if (flowerbed[i] == 0 &&
                (i == 0 || flowerbed[i - 1] == 0) &&
                (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
            {
                flowerbed[i++] = 1;
                count++;
            }
            if (count >= n)
                return true;
            i++;
        }
        return false;
    }
}

class Q605_CanPlaceFlowersTestData : TestData
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

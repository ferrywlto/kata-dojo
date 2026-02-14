
class Q941_ValidMountainArray
{
    // TC: O(n), n is length of array
    // SC: O(1), no extra data structure used
    public bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3) return false;

        bool wentUp = false;
        bool wentDown = false;
        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                if (!wentUp && !wentDown) wentUp = true;
                // cannot go up once it goes down
                else if (wentDown) return false;
            }
            else if (arr[i] < arr[i - 1])
            {
                if (wentUp && !wentDown) wentDown = true;
                // cannot go down before go up
                else if (!wentUp) return false;
            }
            else return false;
        }
        return wentUp && wentDown;
    }
}

class Q941_ValidMountainArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{2,1}, false],
        [new int[]{3,5,5}, false],
        [new int[]{0,3,2,1}, true],
        [new int[]{0,3,2,1,1}, false],
        [new int[]{0,3,2,1,3}, false],
        [new int[]{0,0,3,2,1}, false],
        [new int[]{0,1,2,3,4,5,6,7,8,9}, false],
    ];
}

public class Q941_ValidMountainArrayTests
{
    [Theory]
    [ClassData(typeof(Q941_ValidMountainArrayTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q941_ValidMountainArray();
        var actual = sut.ValidMountainArray(input);
        Assert.Equal(expected, actual);
    }
}

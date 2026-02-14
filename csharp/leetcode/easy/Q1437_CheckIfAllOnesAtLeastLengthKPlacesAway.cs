
class Q1437_CheckIfAllOnesAtLeastLengthKPlacesAway
{
    // TC: O(n), it have to iterate all n elements in nums, then iterate m 1's index, since m <= n thus O(n)
    // SC: O(1), improved from O(m) by not storing 1s indexes
    public bool KLengthApart(int[] nums, int k)
    {
        int? lastOne = null;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                if (lastOne != null && i - lastOne - 1 < k) return false;
                lastOne = i;
            }
        }
        return true;
    }
}
class Q1437_CheckIfAllOnesAtLeastLengthKPlacesAwayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,0,0,0,1,0,0,1}, 2, true],
        [new int[] {1,0,0,1,0,1}, 2, false],
        [new int[] {0,0,1,0,1}, 2, false],
        [new int[] {0,0,1,0,0}, 2, true],
        [new int[] {0,0,0,0,0}, 1, true],
    ];
}
public class Q1437_CheckIfAllOnesAtLeastLengthKPlacesAwayTests
{
    [Theory]
    [ClassData(typeof(Q1437_CheckIfAllOnesAtLeastLengthKPlacesAwayTestData))]
    public void Q1437_CheckIfAllOnesAtLeastLengthKPlacesAway(int[] input, int k, bool expected)
    {
        var sut = new Q1437_CheckIfAllOnesAtLeastLengthKPlacesAway();
        var actual = sut.KLengthApart(input, k);
        Assert.Equal(expected, actual);
    }
}

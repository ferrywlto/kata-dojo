
class Q1437_CheckIfAllOnesAtLeastLengthKPlacesAway
{
    // TC: O(n+m), it have to iterate all n elements in nums, then iterate m 1's index
    // SC: O(m), where m is the number of 1's in nums 
    public bool KLengthApart(int[] nums, int k)
    {
        var oneIndexes = new List<int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) oneIndexes.Add(i);
        }
        if (oneIndexes.Count == 0) return true;

        for (var j = 1; j < oneIndexes.Count; j++)
        {
            if (oneIndexes[j] - oneIndexes[j - 1] - 1 < k) return false;
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
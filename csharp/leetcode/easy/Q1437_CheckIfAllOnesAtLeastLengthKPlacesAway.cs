
class Q1437_CheckIfAllOnesAtLeastLengthKPlacesAway
{
    public bool KLengthApart(int[] nums, int k) 
    {
        return false;    
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
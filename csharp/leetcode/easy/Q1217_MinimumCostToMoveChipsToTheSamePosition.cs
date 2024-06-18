class Q1217_MinimumCostToMoveChipsToTheSamePosition
{
    // TC: O(n), each position have to iterate once
    // SC: O(1), fixed to 2 variables
    public int MinCostToMoveChips(int[] position)
    {
        // odd to odd and even to even is cost 0
        int evenCount = 0, oddCount = 0;
        foreach (var pos in position)
        {
            if (pos % 2 == 0)
                evenCount++;
            else
                oddCount++;
        }
        // eventually it will remain position n and n+1, which must have cost 1 to move a chip, 
        // so we take the smaller pile 
        return Math.Min(evenCount, oddCount);
    }
}
class Q1217_MinimumCostToMoveChipsToTheSamePositionTestData : TestData
{
    protected override List<object[]> Data =>
    [

        [new int[] {1,2,3}, 1],
        [new int[] {2,2,2,3,3}, 2],
        [new int[] {1,1000000000}, 1],
        [new int[] {6,4,7,8,2,10,2,7,9,7}, 4],
    ];
}
public class Q1217_MinimumCostToMoveChipsToTheSamePositionTests
{
    [Theory]
    [ClassData(typeof(Q1217_MinimumCostToMoveChipsToTheSamePositionTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1217_MinimumCostToMoveChipsToTheSamePosition();
        var actual = sut.MinCostToMoveChips(input);
        Assert.Equal(expected, actual);
    }
}
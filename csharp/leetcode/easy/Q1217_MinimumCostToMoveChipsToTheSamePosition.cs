class Q1217_MinimumCostToMoveChipsToTheSamePosition
{
    public int MinCostToMoveChips(int[] position)
    {
        return 0;
    }
}
class Q1217_MinimumCostToMoveChipsToTheSamePositionTestData : TestData
{
    protected override List<object[]> Data =>
    [

        [new int[] {1,2,3}, 1],
        [new int[] {2,2,2,3,3}, 2],
        [new int[] {1,1000000000}, 1],
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
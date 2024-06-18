class Q1217_MinimumCostToMoveChipsToTheSamePosition
{
    public int MinCostToMoveChips(int[] position)
    {
        var dict = new Dictionary<int, int>();
        var result = int.MaxValue;
        // var max = int.MinValue;
        // var maxPos = 0;
        foreach(var pos in position)
        {
            if (dict.TryGetValue(pos, out var value)) 
                dict[pos] = ++value;
            else
                dict.Add(pos, 1);
        }
        // try O(n^2) first, test all combination
        foreach(var p1 in dict)
        {
            var temp = 0;
            foreach(var p2 in dict)
            {
                if (p1.Key != p2.Key && Math.Abs(p1.Key - p2.Key) % 2 != 0)
                    temp += p2.Value;
            }
            if (temp < result) result = temp;
        }
        return result;
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
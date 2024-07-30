class Q1560_MostVisitedSectorInCircularTrack
{
    // TC: O(n*m), where n is rounds - 1 * sectors visited per round
    // SC: O(n), where n is number of visited sector
    public IList<int> MostVisited(int n, int[] rounds)
    {
        if (rounds.Length == 1) return rounds;
        var maxCount = 0;
        var dict = new Dictionary<int, int>();

        for(var i=1; i<rounds.Length; i++)
        {
            var current = rounds[i - 1];
            var next = rounds[i];
            while (current != next)
            {
                if (dict.TryGetValue(current, out var value))
                    dict[current] = ++value;
                else
                    dict[current] = 1;

                if (dict[current] > maxCount) 
                    maxCount = dict[current];

                if (current == n) current = 1;
                else current++;
            }
        }
        var last = rounds[^1];
        if (dict.TryGetValue(last, out var value2))
            dict[last] = ++value2;
        else
            dict[last] = 1;

        if (dict[last] > maxCount) 
            maxCount = dict[last];

        return dict
            .Where(x => x.Value == maxCount)
            .Select(x => x.Key)
            .ToList();
    }
}
class Q1560_MostVisitedSectorInCircularTrackTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [4, new int[] {1,3,1,2}, new List<int> {1,2}],
        [2, new int[] {2,1,2,1,2,1,2,1,2}, new List<int> {2}],
        [7, new int[] {1,3,5,7}, new List<int> {1,2,3,4,5,6,7}],
    ];
}
public class Q1560_MostVisitedSectorInCircularTrackTests
{
    [Theory]
    [ClassData(typeof(Q1560_MostVisitedSectorInCircularTrackTestData))]
    public void OfficialTestCases(int n, int[] sectors, List<int> expected)
    {
        var sut = new Q1560_MostVisitedSectorInCircularTrack();
        var actual = sut.MostVisited(n, sectors);
        Assert.Equal(expected, actual);
    }
}
class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimes
{
    public bool ContainsPattern(int[] arr, int m, int k)
    {
        var full = string.Join(',', arr);

        for(var i=0; i<arr.Length-m+1; i++)
        {
            var list = new List<int>();
            for(var j=i; j<i+m; j++) list.Add(arr[j]);

            var repeatedList = new List<int>();
            var x = Enumerable.Repeat(list, k);
            foreach(var rl in x)
                repeatedList.AddRange(rl);

            var patternToFind = string.Join(',', repeatedList);

            if (full.Contains(patternToFind)) return true;
        }
        return false;
    }
}
class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimesTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,2,4,4,4,4}, 1, 3, true],
        [new int[] {1,2,1,2,1,1,1,3}, 2, 2, true],
        [new int[] {1,2,1,2,1,3}, 2, 3, false],
        [new int[] {1,2,3,1,2}, 2, 2, false],
        [new int[] {3,2,2,1,2,2,1,1,1,2,3,2,2}, 3, 2, true],
        [new int[] {2,2}, 1, 2, true],
        [new int[] {2,1,2,2,2,2,2,2}, 2, 2, true],
        [new int[] {2,2,2,2}, 2, 3, false],
    ];
}
public class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimesTests
{
    [Theory]
    [ClassData(typeof(Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimesTestData))]
    public void OfficialTestCases(int[] input, int m, int k, bool expected)
    {
        var sut = new Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimes();
        var actual = sut.ContainsPattern(input, m, k);
        Assert.Equal(expected, actual);
    }
}
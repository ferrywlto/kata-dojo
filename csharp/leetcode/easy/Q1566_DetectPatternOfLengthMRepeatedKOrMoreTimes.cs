class Q1566_DetectPatternOfLengthMRepeatedKOrMoreTimes
{
    // TC: O(n), where n is length of arr * m * k
    // SC: O(1), space used is fixed
    public bool ContainsPattern(int[] arr, int m, int k)
    {
        int n = arr.Length;
        // To have a list of m size repeated k times it must exist before position (n - m*k); 
        int patternLength = m * k;
        for (int i = 0; i <= n - patternLength; i++)
        {
            bool match = true;
            // Check if the subsequent items repeating in a pattern
            for (int j = 0; j < patternLength; j++)
            {
                // The trick here is j % m
                if (arr[i + j] != arr[i + j % m])
                {
                    match = false;
                    break;
                }
            }
            if (match) return true;
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

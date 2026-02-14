class Q1502_CanMakeArithmeticProgressionFromSequence
{
    // TC: O(n log n), dominated by Array.Sort(), then n-1 to get the diff of each pair, thus O(n log n)
    // SC: O(1), the space used are fixed.
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        Array.Sort(arr);
        var diff = arr[1] - arr[0];
        for (var i = 2; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] != diff) return false;
        }
        return true;
    }
}
class Q1502_CanMakeArithmeticProgressionFromSequenceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {3,5,1}, true],
        [new int[] {1,2,4}, false],
    ];
}
public class Q1502_CanMakeArithmeticProgressionFromSequenceTests
{
    [Theory]
    [ClassData(typeof(Q1502_CanMakeArithmeticProgressionFromSequenceTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1502_CanMakeArithmeticProgressionFromSequence();
        var actual = sut.CanMakeArithmeticProgression(input);
        Assert.Equal(expected, actual);
    }
}

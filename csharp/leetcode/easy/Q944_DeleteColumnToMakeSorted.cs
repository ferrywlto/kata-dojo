class Q944_DeleteColumnToMakeSorted
{
    // TC: O(n), n is total characters in strs
    // SC: O(1), didn't use any data structure
    public int MinDeletionSize(string[] strs)
    {
        if (strs.Length <= 1 || strs[0].Length == 0) return 0;

        var cols = strs[0].Length;

        var result = 0;

        for (var col = 0; col < cols; col++)
        {
            for (var row = 1; row < strs.Length; row++)
            {
                if (strs[row][col] < strs[row - 1][col])
                {
                    result++;
                    break;
                }
            }
        }
        return result;
    }
}

class Q944_DeleteColumnToMakeSortedTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"cba","daf","ghi"}, 1],
        [new string[] {"a","b"}, 0],
        [new string[] {"zyx","wvu","tsr"}, 3],
    ];
}

public class Q944_DeleteColumnToMakeSortedTests
{
    [Theory]
    [ClassData(typeof(Q944_DeleteColumnToMakeSortedTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q944_DeleteColumnToMakeSorted();
        var actual = sut.MinDeletionSize(input);
        Assert.Equal(expected, actual);
    }
}

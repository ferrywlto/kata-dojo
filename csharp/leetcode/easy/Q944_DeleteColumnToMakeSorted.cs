class Q944_DeleteColumnToMakeSorted
{
    public int MinDeletionSize(string[] strs)
    {
        return 0;
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
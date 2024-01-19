using dojo.leetcode;

public class Q228_SummaryRanges
{
    public IList<string> SummaryRanges(int[] nums)
    {
        // use 2 int pointers
        return new List<string>();
    }
}

public class Q228_SummaryRangesTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0, 1, 2, 4, 5, 7}, new string[]{"0->2", "4->5", "7"}],
        [new int[]{0, 2, 3, 4, 6, 8, 9}, new string[]{"0", "2->4", "6", "8->9"}],
    ];
}

public class Q228_SummaryRangesTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q228_SummaryRangesTestData))]
    public void OfficialTestCases(int[] input, string[] expected)
    {
        var sut = new Q228_SummaryRanges();
        var actual = sut.SummaryRanges(input);

        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
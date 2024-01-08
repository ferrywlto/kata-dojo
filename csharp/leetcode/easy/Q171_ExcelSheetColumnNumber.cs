using dojo.leetcode;

public class Q171_ExcelSheetColumnNumberTestData: TestDataBase 
{
    protected override List<object[]> Data() => 
    [
        ["A", 1],
        ["AB", 28],
        ["ZY", 701],
        ["AZ", 52]
    ];
}
public class Q171_ExcelSheetColumnNumberTests(ITestOutputHelper output): TestBase(output) 
{
    [Theory]
    [ClassData(typeof(Q171_ExcelSheetColumnNumberTestData))]
    public void OfficialTestCases(string columnTitle, int expected) 
    {
        var sut = new Q171_ExcelSheetColumnNumber();
        var res = sut.TitleToNumber(columnTitle);

        Assert.Equal(expected, res);
    }
}
public class Q171_ExcelSheetColumnNumber 
{
    public int TitleToNumber(string columnTitle) 
    {
        return 0;
    }
}
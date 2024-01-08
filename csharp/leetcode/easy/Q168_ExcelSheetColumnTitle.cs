using dojo.leetcode;

public class Q168_ExcelSheetColumnTitleTestData : TestDataBase 
{
    protected override List<object[]> Data() => 
    [
        [1, "A"],
        [28, "AB"],
        [701, "ZY"]
    ];
}

public class Q168_ExcelSheetColumnTitleTests(ITestOutputHelper output) : TestBase(output) 
{
    [Theory]
    [ClassData(typeof(Q168_ExcelSheetColumnTitleTestData))]
    public void Test(int columnNumber, string expected) 
    {
        var sut = new Q168_ExcelSheetColumnTitle();
        var res = sut.ConvertToTitle(columnNumber);

        Assert.Equal(expected, res);
    }
}

public class Q168_ExcelSheetColumnTitle 
{
    public string ConvertToTitle(int columnNumber) 
    {
        return string.Empty;
    }
}
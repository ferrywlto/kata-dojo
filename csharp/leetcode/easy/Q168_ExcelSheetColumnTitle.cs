namespace dojo.leetcode;
using System.Text;

public class Q168_ExcelSheetColumnTitleTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1, "A"],
        [28, "AB"],
        [701, "ZY"],
        [52, "AZ"]
    ];
}

public class Q168_ExcelSheetColumnTitleTests(ITestOutputHelper output) : BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q168_ExcelSheetColumnTitleTestData))]
    public void OfficialTestCases(int columnNumber, string expected)
    {
        var sut = new Q168_ExcelSheetColumnTitle();
        var res = sut.ConvertToTitle(columnNumber);

        Assert.Equal(expected, res);
    }
}

public class Q168_ExcelSheetColumnTitle
{
    // O(log n)
    public string ConvertToTitle(int columnNumber)
    {
        var stringBuilder = new StringBuilder();
        while (columnNumber > 26)
        {
            var reminder = columnNumber % 26;
            stringBuilder.Insert(0, GetChar(reminder));
            columnNumber /= 26;
            // Tricky part
            if (reminder == 0) columnNumber -= 1;
        }
        stringBuilder.Insert(0, GetChar(columnNumber));
        return stringBuilder.ToString();
    }
    // O(1)
    public char GetChar(int input) =>
        input == 0
        ? (char)90 // handle Z 
        : (char)(input + 64);
}
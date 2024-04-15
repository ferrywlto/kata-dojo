public class Q171_ExcelSheetColumnNumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["A", 1],
        ["AB", 28],
        ["ZY", 701],
        ["AZ", 52]
    ];
}

public class Q171_ExcelSheetColumnNumberTests
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
    // Improved to TC: O(n), SC: O(n)
    public int TitleToNumber(string columnTitle)
    {
        int result = 0;
        int multiplier = 1;

        for (int i = columnTitle.Length - 1; i >= 0; i--)
        {
            int number = GetNumber(columnTitle[i]);
            result += number * multiplier;
            multiplier *= 26;
        }

        return result;
    }

    // O(1)
    public int GetNumber(char input) =>
        input == 'Z'
        ? 26 // handle Z 
        : input - 64;
}
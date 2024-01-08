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
        var result = 0;

        var charArray = columnTitle.ToCharArray().ToList();
        while (charArray.Count > 0) 
        {
            var number = GetNumber(charArray[0]);
            // Console.WriteLine($"char: {charArray[0]}, number: {number}, length: {charArray.Count}");
            result += number * (int)Math.Pow(26, charArray.Count-1);
            charArray.RemoveAt(0);
        }

        return result;
    }

    public int GetNumber(char input) => 
        input == 'Z' 
        ? 26 // handle Z 
        : input - 64;
}
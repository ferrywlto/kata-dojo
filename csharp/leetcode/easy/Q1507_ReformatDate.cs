class Q1507_ReformatDate
{
    // TC: O(1)
    // SC: O(1)
    readonly Dictionary<string, string> Months = new Dictionary<string, string>() {
        {"Jan", "01" },
        {"Feb", "02"},
        {"Mar", "03"},
        {"Apr", "04"},
        {"May", "05"},
        {"Jun", "06"},
        {"Jul", "07"},
        {"Aug", "08"},
        {"Sep", "09"},
        {"Oct", "10"},
        {"Nov", "11"},
        {"Dec", "12"},
    };
    public string ReformatDate(string date)
    {
        var parts = date.Split(' ');
        var day = int.Parse(parts[0]
            .Replace("th", string.Empty)
            .Replace("st", string.Empty)
            .Replace("nd", string.Empty)
            .Replace("rd", string.Empty));
        return $"{parts[2]}-{Months[parts[1]]}-{day:d2}";
    }
}
class Q1507_ReformatDateTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["20th Oct 2052", "2052-10-20"],
        ["6th Jun 1933", "1933-06-06"],
        ["26th May 1960", "1960-05-26"],
    ];
}
public class Q1507_ReformatDateTests
{
    [Theory]
    [ClassData(typeof(Q1507_ReformatDateTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1507_ReformatDate();
        var actual = sut.ReformatDate(input);
        Assert.Equal(expected, actual);
    }
}
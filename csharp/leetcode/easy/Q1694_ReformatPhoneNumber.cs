using System.Text;

class Q1694_ReformatPhoneNumber
{
    // TC: O(n+m), where n is length of number
    // SC: O(n+m), where n is length of number for string builder plus m for parts
    public string ReformatNumber(string number) 
    {
        var sb = new StringBuilder();
        foreach(char n in number)
        {
            if (n > 47 && n < 58) sb.Append(n);
        }
        var digits = sb.ToString();
        var parts = new List<string>();
        var idx = 0;
        while(digits.Length - idx > 4)
        {
            parts.Add(digits.Substring(idx, 3));
            idx += 3;
        }
        var reminder = digits.Length - idx;
        if(reminder == 2)
        {
            parts.Add(digits.Substring(idx, 2));
        }
        else if (reminder == 3)
        {
            parts.Add(digits.Substring(idx, 3));
        }
        else 
        {
            parts.Add(digits.Substring(idx, 2));
            idx+=2;
            parts.Add(digits.Substring(idx, 2));
        }
        return string.Join('-', parts);    
    }    
}
class Q1694_ReformatPhoneNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [
        ["1-23-45 6", "123-456"],
        ["123 4-567", "123-45-67"],
        ["123 4-5678", "123-456-78"],
    ];
}
public class Q1694_ReformatPhoneNumberTests
{
    [Theory]
    [ClassData(typeof(Q1694_ReformatPhoneNumberTestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q1694_ReformatPhoneNumber();
        var actual = sut.ReformatNumber(input);
        Assert.Equal(expected, actual);
    }
}
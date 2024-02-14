
using System.Text;

namespace dojo.leetcode;

public class Q482_LicenseKeyFormatting
{
    // TC: O(n), SC: O(n)
    public string LicenseKeyFormatting(string s, int k)
    {
        var sb = new StringBuilder(s);
        sb.Replace("-", string.Empty);
        Console.WriteLine($"after replace: {sb}");
        for(var i=0; i<sb.Length; i++)
        {
            sb[i] = ToUpper(sb[i]);
        }
        if (k >= sb.Length) return sb.ToString();

        Console.WriteLine(sb);

        for (var j=sb.Length-k; j>=1; j-=k) 
        {
            sb.Insert(j, "-");
            Console.WriteLine(sb);
        }
        
        Console.WriteLine(sb);
        return sb.ToString();
    }

    public char ToUpper(char input) 
        => (input >= 97 && input <= 122) 
        ? (char)(input - 32) 
        : input;
 }

public class Q482_LicenseKeyFormattingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["5F3Z-2e-9-w", 4, "5F3Z-2E9W"],
        ["5F3Z-2e-9-w", 7, "5-F3Z2E9W"],
        ["2-5g-3-J", 2, "2-5G-3J"],
        ["r", 1, "R"],
        ["a-----a", 2, "AA"],
        ["---", 3, ""],
    ];
}

public class Q482_LicenseKeyFormattingTests
{
    [Theory]
    [ClassData(typeof(Q482_LicenseKeyFormattingTestData))]
    public void OfficialTestCases(string input, int k, string expected)
    {
        var sut = new Q482_LicenseKeyFormatting();
        var actual = sut.LicenseKeyFormatting(input, k);
        Assert.Equal(expected, actual);
    }
}

using System.Text;

namespace dojo.leetcode;

public class Q482_LicenseKeyFormatting
{
    public string LicenseKeyFormatting(string s, int k)
    {
        var sb = new StringBuilder(s);
        sb.Replace("-", string.Empty);
        Console.WriteLine(sb);
        sb.ToString().ToUpperInvariant();
        Console.WriteLine(sb);
        return string.Empty;
    }
}

public class Q482_LicenseKeyFormattingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["5F3Z-2e-9-w", 4, "5F3Z-2E9W"],
        ["2-5g-3-J", 2, "2-5G-3J"]
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
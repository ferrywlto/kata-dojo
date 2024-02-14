using System.Text;

namespace dojo.leetcode;

public class Q482_LicenseKeyFormatting
{
    // TC: O(n), SC: O(n)
    public string LicenseKeyFormatting(string s, int k)
    {
        var sb = new StringBuilder();
        int count = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] != '-')
            {
                if (count != 0 && count % k == 0)
                {
                    sb.Insert(0, '-');
                }
                sb.Insert(0, char.ToUpper(s[i]));
                count++;
            }
        }
        return sb.ToString();
    }
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
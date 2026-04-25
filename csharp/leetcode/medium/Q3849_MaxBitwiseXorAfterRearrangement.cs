using System.Text;

public class Q3849_MaxBitwiseXorAfterRearrangement
{
    // TC: O(n), n scale with length of s
    // SC: O(n), for storing the result
    public string MaximumXor(string s, string t)
    {
        var oneCount = 0;
        foreach (var c in t) if (c == '1') oneCount++;

        // For max, flip all 0 to 1
        // then if still have one left in t, flip the 1 from right to left to minimize loss
        var zeroIdx = new List<int>();
        var oneIdx = new List<int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
                zeroIdx.Add(i);

            var reverseIdx = s.Length - i - 1;
            if (s[reverseIdx] == '1')
                oneIdx.Add(reverseIdx);
        }

        var sb = new StringBuilder(s);
        var startIdx = 0;
        while (oneCount > 0 && startIdx < zeroIdx.Count)
        {
            sb[zeroIdx[startIdx++]] = '1';
            oneCount--;
        }

        var tailIdx = 0;
        while (oneCount > 0 && tailIdx < oneIdx.Count)
        {
            sb[oneIdx[tailIdx++]] = '0';
            oneCount--;
        }

        return sb.ToString();
    }
    public static TheoryData<string, string, string> TestData => new()
    {
        {"101", "011", "110"},
        {"0110", "1110", "1101"},
        {"0101", "1001", "1111"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, string t, string expected)
    {
        var actual = MaximumXor(s, t);
        Assert.Equal(expected, actual);
    }
}

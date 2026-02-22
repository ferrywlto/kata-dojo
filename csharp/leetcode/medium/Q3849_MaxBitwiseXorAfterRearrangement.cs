using System.Text;

public class Q3849_MaxBitwiseXorAfterRearrangement//(ITestOutputHelper output)
{
    public string MaximumXor(string s, string t)
    {
        var oneCount = 0;
        foreach(var c in t) if (c == '1') oneCount++;

        // For max, flip all 0 to 1
        // then if still have one left in t, flip the 1 from right to left to minimize loss
        var flipIdx = new List<int>();

        var sb = new StringBuilder(s);
        for(var i =0; i<sb.Length; i++)
        {
            if(sb[i] == '0' && oneCount > 0)
            {
                flipIdx.Add(i);
                oneCount--;
            }
        }

        var tailIdx = sb.Length -1;
        while(oneCount>0 && tailIdx >=0)
        {
            if(sb[tailIdx] == '1')
            {
                flipIdx.Add(tailIdx);
                oneCount--;
            }
            tailIdx--;
        }

        // output.WriteLine(string.Join(',', flipIdx));
        // Perform the actual flip
        foreach(var idx in flipIdx)
        {
            if(sb[idx] == '1') sb[idx] = '0';
            else sb[idx] = '1';
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

using System.Text;

public class Q1980_FindUniqueBinaryString
{
    // TC: O(n), n scale with length of nums
    // SC: O(n)
    public string FindDifferentBinaryString(string[] nums)
    {
        var sb = new StringBuilder();
        // Since it differs from each string at its own index, it can’t equal any of them.
        for (var i = 0; i < nums.Length; i++)
            sb.Append(nums[i][i] == '0' ? '1' : '0');

        return sb.ToString();
    }
    public static TheoryData<string[], string> TestData => new()
    {
        {["01","10"], "11"},
        {["10","11"], "00"},
        {["0","01"], "11"},
        {["111","011","001"], "101"},
        {["1"], "0"},
        {["0"], "1"},
        {
            [
                "11010011101",
                "10110010101",
                "01011001111",
                "01100011001",
                "00110110110",
                "10110011011",
                "11110000010",
                "01110000000",
                "00110011100",
                "11111011100",
                "11111110110"
             ],
             "00000000000"
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, string expected)
    {
        var actual = FindDifferentBinaryString(input);
        Assert.Equal(actual.Length, input.Length);
        Assert.False(input.Contains(actual));
        Assert.False(input.Contains(expected));
    }
}

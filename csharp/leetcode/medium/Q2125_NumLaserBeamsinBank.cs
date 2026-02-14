public class Q2125_NumLaserBeamsinBank
{
    // TC: O(n^2), n scale with length of bank, have to iterate all characters
    // SC: O(1), space used does not scale with input
    public int NumberOfBeams(string[] bank)
    {
        var result = 0;
        var prev = 0;
        for (var i = 0; i < bank.Length; i++)
        {
            var row = bank[i];
            var count = 0;
            for (var j = 0; j < row.Length; j++)
            {
                if (row[j] == '1') count++;
            }
            if (count > 0)
            {
                result += prev * count;
                prev = count;
            }
        }

        return result;
    }
    public static TheoryData<string[], int> TestData => new()
    {
        {["011001","000000","010100","001000"], 8},
        {["000","111","000"], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = NumberOfBeams(input);
        Assert.Equal(expected, actual);
    }
}

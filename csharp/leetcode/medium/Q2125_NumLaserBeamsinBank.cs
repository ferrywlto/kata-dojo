public class Q2125_NumLaserBeamsinBank
{
    public int NumberOfBeams(string[] bank)
    {
        var result = 0;
        var prevDevices = CountDevices(bank[0]);
        for (var i = 1; i < bank.Length; i++)
        {
            var nextDevices = CountDevices(bank[i]);
            if (nextDevices != 0)
            {
                result += prevDevices * nextDevices;
                prevDevices = nextDevices;
            }
        }
        return result;
    }
    private int CountDevices(string input)
    {
        var devices = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '1') devices++;
        }
        return devices;
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
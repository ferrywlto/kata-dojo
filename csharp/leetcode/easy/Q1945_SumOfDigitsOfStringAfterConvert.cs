using System.Text;

class Q1945_SumOfDigitsOfStringAfterConvert : TestSubject
{
    public Q1945_SumOfDigitsOfStringAfterConvert(ITestOutputHelper? output) : base(output!) {}

    // TC: O(n), where n scale with length of s times k
    // SC: O(n), where n scale with length of s
    public int GetLucky(string s, int k)
    {
        var sb = new StringBuilder();
        foreach (var c in s) sb.Append(GetCharValue(c));

        var sum = 0;
        var runCount = 0;
        while (runCount < k)
        {
            var innerSum = 0;
            var intStr = sb.ToString();
            sb.Clear();
            foreach (var c in intStr)
            {
                var num = c - '0';
                innerSum += num;
            }
            sum = innerSum;
            sb.Append(innerSum);
            runCount++;
        }
        return sum;
    }
    public int GetCharValue(char c) => c - 'a' + 1;
}
class Q1945_SumOfDigitsOfStringAfterConvertTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["iiii", 1, 36],
        ["leetcode", 2, 6],
        ["zbax", 2, 8],
    ];
}
public class Q1945_SumOfDigitsOfStringAfterConvertTests(ITestOutputHelper output) : TestBase(output)
{
    [Theory]
    [ClassData(typeof(Q1945_SumOfDigitsOfStringAfterConvertTestData))]
    public void OfficialTestCases(string input, int k, int expected)
    {
        var sut = new Q1945_SumOfDigitsOfStringAfterConvert(Output);
        var actual = sut.GetLucky(input, k);
        Assert.Equal(expected, actual);
    }
}
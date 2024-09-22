using System.Text;

class Q1945_SumOfDigitsOfStringAfterConvert
{
    // TC: O(n), where n scale with length of s times k
    // SC: O(n), where n scale with length of s
    public int GetLucky(string s, int k)
    {
        var sb = new StringBuilder();
        foreach (var c in s) sb.Append(GetCharValue(c));
        Console.WriteLine($"input: {sb}");
        var sum = 0;
        var runCount = 0;
        while (runCount < k)
        {
            var intStr = sb.ToString();

            sb.Clear();
            Console.WriteLine($"loop {runCount}: {intStr}");
            var innerSum = 0;
            foreach (var c in intStr)
            {
                var num = c - '0';
                Console.WriteLine($"c: {c} v: {num}");
                innerSum += num;
            }
            sum = innerSum;
            sb.Append(innerSum);
            runCount++;
        }
        Console.WriteLine($"final: {sb}");
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
public class Q1945_SumOfDigitsOfStringAfterConvertTests
{
    [Theory]
    [ClassData(typeof(Q1945_SumOfDigitsOfStringAfterConvertTestData))]
    public void OfficialTestCases(string input, int k, int expected)
    {
        var sut = new Q1945_SumOfDigitsOfStringAfterConvert();
        var actual = sut.GetLucky(input, k);
        Assert.Equal(expected, actual);
    }
}
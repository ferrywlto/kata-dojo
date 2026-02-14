using System.Text;

public class Q2231_LargestNumberAfterDigitSwapsByParity(ITestOutputHelper output)
{
    // TC: O(d log d), d scale with digits in num
    // SC: O(d), d scale with digits in num
    public int LargestInteger(int num)
    {
        var evenNums = new List<int>();
        var oddNums = new List<int>();
        var numStr = num.ToString();

        var parity = new int[numStr.Length];
        for (var i = 0; i < numStr.Length; i++)
        {
            var val = numStr[i] - '0';
            if (val % 2 == 0)
            {
                evenNums.Add(val);
                parity[i] = 0;
            }
            else
            {
                oddNums.Add(val);
                parity[i] = 1;
            }

        }
        output.WriteLine(string.Join(',', parity));
        evenNums.Sort();
        evenNums.Reverse();
        oddNums.Sort();
        oddNums.Reverse();

        var sb = new StringBuilder();
        var evenIdx = 0;
        var oddIdx = 0;
        for (var j = 0; j < numStr.Length; j++)
        {
            if (parity[j] == 0)
            {
                sb.Append(evenNums[evenIdx]);
                evenIdx++;
            }
            else
            {
                sb.Append(oddNums[oddIdx]);
                oddIdx++;
            }
        }

        return int.Parse(sb.ToString());
    }
    public static List<object[]> TestData =>
    [
        [1234, 3412],
        [4120, 4120],
        [65875, 87655],
        [80546, 86540],
        [60, 60],
        [247, 427],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = LargestInteger(input);
        Assert.Equal(expected, actual);
    }
}

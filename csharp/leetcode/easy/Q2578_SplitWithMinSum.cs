using System.Text;

public class Q2578_SplitWithMinSum
{
    // TC: O(d), d scale with digits of num, input at most 10 digits
    // SC: O(d), same as time, length of sb1 and sb2 at most equals to d, dict is also d
    public int SplitNum(int num)
    {
        var digits = new int[10];

        while (num > 0)
        {
            var digit = num % 10;
            digits[digit]++;
            num /= 10;
        }

        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();
        var count = 0;
        for (var i = 0; i < 10; i++)
        {
            var freq = digits[i];

            while (freq > 0)
            {
                if (count % 2 == 0) sb1.Append(i);
                else sb2.Append(i);
                count++;
                freq--;
            }
        }
        return int.Parse(sb1.ToString()) + int.Parse(sb2.ToString());
    }
    public static List<object[]> TestData =>
    [
        [4325, 59],
        [687, 75],
        [11, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SplitNum(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2566_MaxDifferenceByRemappingDigit
{
    // TC: O(d), d scale with digits of num
    // SC: O(d), same as time for storing the num in string
    public int MinMaxDifference(int num)
    {
        var maxStr = num.ToString();
        var max = num;
        for (var i = 0; i < maxStr.Length; i++)
        {
            var temp = maxStr[i];
            if (temp != '9')
            {
                max = int.Parse(maxStr.Replace(temp, '9'));
                break;
            }
        }
        var minStr = num.ToString();
        var min = num;
        for (var j = 0; j < minStr.Length; j++)
        {
            var temp = minStr[j];
            if (temp != '0')
            {
                min = int.Parse(minStr.Replace(temp, '0'));
                break;
            }
        }
        return max - min;
    }
    public static List<object[]> TestData =>
    [
        [99999, 99999],
        [11891, 99009],
        [90, 99],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinMaxDifference(input);
        Assert.Equal(expected, actual);
    }
}

public class Q2269_FindTheKBeautyOfNumber
{
    // TC: O(d), d scale with digits of num
    // SC: O(k), k scale with size of k to hold k size substring to convert into number
    public int DivisorSubstrings(int num, int k)
    {
        var result = 0;
        var numStr = num.ToString();
        for (var i = 0; i < numStr.Length - k + 1; i++)
        {
            var extract = numStr[i..(i + k)];
            var divisor = int.Parse(extract);
            if (divisor != 0 && num % divisor == 0) result++;
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [240, 2, 2],
        [430043, 2, 2],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int k, int expected)
    {
        var actual = DivisorSubstrings(input, k);
        Assert.Equal(expected, actual);
    }
}

public class Q3270_FindKeyOfNumbers
{
    // TC: O(1)
    // SC: O(1)
    public int GenerateKey(int num1, int num2, int num3)
    {
        var base10 = 1;
        var result = 0;
        for (var i = 0; i < 4; i++)
        {
            var minDigit = num1 % 10;
            var digit2 = num2 % 10;
            var digit3 = num3 % 10;
            if (digit2 < minDigit) minDigit = digit2;
            if (digit3 < minDigit) minDigit = digit3;
            result += minDigit * base10;
            base10 *= 10;
            num1 /= 10;
            num2 /= 10;
            num3 /= 10;
        }
        return result;
    }
    public static TheoryData<int, int, int, int> TestData => new()
    {
        {1, 10 ,1000, 0},
        {987, 879 ,798, 777},
        {1, 2 ,3, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, int input3, int expected)
    {
        var actual = GenerateKey(input1, input2, input3);
        Assert.Equal(expected, actual);
    }
}

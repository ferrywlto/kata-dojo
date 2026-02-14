class Q476_NumberComplement
{
    // Constraints
    // 1 <= num < 2^31
    // TC: O(1), SC: O(1)
    public int FindComplement(int num)
    {
        // Can't simply use ~ operator because of leading zeros
        var bitsOfNum = (int)Math.Log(num, 2) + 1;
        var complementedStr = Convert.ToString(~num, 2);
        var trimmed = complementedStr[^bitsOfNum..];
        var result = int.Parse(trimmed, System.Globalization.NumberStyles.BinaryNumber);

        return result;
    }

    // save memory from string and less operations
    public int FindComplementWithMask(int num)
    {
        // e.g. 5 -> 101, 3 bits needed
        var bitsOfNum = (int)Math.Log(num, 2) + 1;
        // e.g. 5, 2^3 = 8 -> 1000, 8 - 1 -> 0111, this is the mask needed to XOR 0101
        var bitMask = (int)Math.Pow(2, bitsOfNum) - 1;
        // 0111 xor
        // 0101 -> 0010 -> 2
        return num ^ bitMask;
    }
}

class Q476_NumberComplementTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [5, 2],
        [1, 0],
        [1024, 1023],
    ];
}

public class Q476_NumberComplementTests
{
    [Theory]
    [ClassData(typeof(Q476_NumberComplementTestData))]
    public void Test(int input, int expected)
    {
        var sut = new Q476_NumberComplement();
        var actual = sut.FindComplementWithMask(input);
        Assert.Equal(expected, actual);
    }
}

namespace dojo.leetcode;

public class Q476_NumberComplement
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
        // Console.WriteLine($"num: {num}, binary:{Convert.ToString(num, 2)}, ~num: {~num}, binary: {complementedStr}, shift: {shiftRequired}, trimed: {trimmed}, result: {result}");

        return result;
    }
}

public class Q476_NumberComplementTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [5, 2],
        [1, 0],
        [1024, 1023],
    ];
}

public class Q476_NumberComplementTest
{
    [Theory]
    [ClassData(typeof(Q476_NumberComplementTestData))]
    public void Test(int input, int expected)
    {
        var sut = new Q476_NumberComplement();
        var actual = sut.FindComplement(input);
        Assert.Equal(expected, actual);
    }
}
class Q415_AddStrings
{
    private const int charBase = 48;
    private static int CharToInt(char c) => c - charBase;
    private static char IntToChar(int i) => (char)(i + charBase);

    // TC:O(n), SC:O(n)
    public string AddStrings(string num1, string num2)
    {
        // ascii table
        // pad 2 string to same size
        // start from end
        // track carry forward
        if (num1.Length > num2.Length) {
            num2 = num2.PadLeft(num1.Length, '0');
        }
        else if(num2.Length > num1.Length) {
            num1 = num1.PadLeft(num2.Length, '0');
        }

        var stack = new Stack<char>();
        // char '0' => dec 48
        bool carryForward = false;
        for(var i = num1.Length-1; i>=0; i--)
        {
            var x = CharToInt(num1[i]) + CharToInt(num2[i]);
            if (carryForward) x++;

            carryForward = x > 9;
            var c = IntToChar(x % 10);
            stack.Push(c);
        }
        if (carryForward) stack.Push('1');
        return string.Join(string.Empty, stack);
    }
}

class Q415_AddStringsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["11", "123", "134"],
        ["456", "77", "533"],
        ["0", "0", "0"],
        ["9", "1", "10"],
        ["99", "1", "100"],
    ];
}

public class Q415_AddStringsTests
{
    [Theory]
    [ClassData(typeof(Q415_AddStringsTestData))]
    public void OfficialTestCase(string num1, string num2, string expected)
    {
        var sut = new Q415_AddStrings();
        var actual = sut.AddStrings(num1, num2);
        Assert.Equal(expected, actual);
    }
}
using System.Text;

public class Q504_Base7
{
    public string ConvertToBase7(int num)
    {
        return ConvertToBase(num, 7);
    }

    // TC: O(log n), SC: O(n)
    public string ConvertToBase(int input, int numBase)
    {
        var sb = new StringBuilder();
        bool negative = false;
        if (input < 0)
        {
            input *= -1;
            negative = true;
        }

        do
        {
            sb.Append(input % numBase);
            input /= numBase;
        } while(input > 0);

        if (negative) sb.Append('-');

        var charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

public class Q504_Base7TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [100, "202"],
        [-7, "-10"],
        [6, "6"],
        [7, "10"],

        // [2, "10"],
        // [3, "11"],
        // [4, "100"],
        // [7, "111"],
        // [10, "1010"],
        // [-10, "-1010"],
    ];
}

public class Q504_Base7Tests(ITestOutputHelper output)
{
    [Theory]
    [ClassData(typeof(Q504_Base7TestData))]
    public void OfficialTestCases(int num, string expected)
    {
        var sut = new Q504_Base7();
        var actual = sut.ConvertToBase7(num);
        output.WriteLine(actual);
        Assert.Equal(expected, actual);
    }
}
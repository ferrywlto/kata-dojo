class Q202_HappyNumbers
{
    // each digit could only be 0-9, can store the sum first
    private readonly Dictionary<int, int> dictOfSq =
        Enumerable
            .Range(0, 10)
            .Select(n => n.ToString()[0])
            .Select(n => new KeyValuePair<int, int>(n, (int)Math.Pow(n - 48, 2)))
            .ToDictionary();

    // TC:O(log n), SC:O(long n)
    public bool IsHappy(int n)
    {
        var seen = new HashSet<int>();

        while (n != 1)
        {
            n = SumOfDigitSquare(n);
            if (seen.Contains(n)) return false;
            seen.Add(n);
        }

        return true;
    }

    private int SumOfDigitSquare(long n)
    {
        var result = 0;
        var str = n.ToString();
        foreach (var i in str) result += dictOfSq[i];
        return result;
    }
}

class Q202_HappyNumbersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [19, true],
        [2, false],
    ];
}

public class Q202_HappyNumbersTests
{
    [Theory]
    [ClassData(typeof(Q202_HappyNumbersTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q202_HappyNumbers();
        var actual = sut.IsHappy(input);

        Assert.Equal(expected, actual);
    }
}

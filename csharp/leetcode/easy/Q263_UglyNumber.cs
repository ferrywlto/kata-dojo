using dojo.leetcode;

public class Q263_UglyNumber
{
    // TC: O(log n), SC:O(1)
    public bool IsUgly(int n)
    {
        if (n <= 0) return false;
        if (n == 1 || n == 2 || n == 3 || n == 5)
            return true;

        var temp = n;
        while(temp != 1)
        {
            if (temp % 5 == 0)
            {
                temp /= 5;
                continue;
            }
            if (temp % 3 == 0)
            {
                temp /= 3;
                continue;
            }
            if (temp % 2 == 0)
            {
                temp /= 2;
                continue;
            }
            return false;
        }

        return true;
    }
}

public class Q263_UglyNumberTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [6, true],
        [1, true],
        [14, false],
        [-6, false],
        [-1, false],
        [-14, false],
        [int.MaxValue, false],
        [int.MinValue, false],
        [0, false]
    ];
}


public class Q263_UglyNumberTests(ITestOutputHelper output):BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q263_UglyNumberTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q263_UglyNumber();
        var actual = sut.IsUgly(input);
        Assert.Equal(expected, actual); 
    }
}
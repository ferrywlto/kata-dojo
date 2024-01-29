
namespace dojo.leetcode;

public class Q326_PowerOfThree
{
    /*
    The notation 1E-14 is a way of representing numbers using scientific notation in programming languages. 
    It stands for 1 times 10 to the power of -14, which is a very small number.

    In decimal form, 1E-14 is 0.00000000000001. 
    This is a very small number close to zero, often used as a tolerance level in numerical comparisons to account for precision errors in floating-point calculations.    
    */
    public bool IsPowerOfThree(int n)
    {
        if (n <= 0) return false;
        // the return type is double, so for n=243 it returns 4.999999999 instead of 5
        // therefore need to check if it is very close to an integer
        var logResult = Math.Log(n, 3); 
        
        return Math.Abs(logResult - Math.Round(logResult)) < 1E-14;
    }

    public bool IsPowerOfThree2(int n)
    {
        if (n <= 0) return false;
        if (n == 1 || n == 3) return true;
        
        long temp = 1;
        while(temp <= n) 
        {
            temp *= 3;
            if (temp == n) return true;
        }
        
        return false;
    }
}

public class Q326_PowerOfThreeTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [27, true],
        [0, false],
        [-1, false],
        [243, true],
        [2188, false],
        [int.MaxValue, false],
    ];
}

public class Q326_PowerOfThreeTests: BaseTest
{
    [Theory]
    [ClassData(typeof(Q326_PowerOfThreeTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q326_PowerOfThree();
        var actual = sut.IsPowerOfThree2(input);
        Assert.Equal(expected, actual);
    }
}
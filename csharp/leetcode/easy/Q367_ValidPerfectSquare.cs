public class Q367_ValidPerfectSquare
{
    // TC: O(log n), SC: O(1)
    public bool IsPerfectSquare(int num)
    {
        if (num == 1) return true;

        long start = 0;
        long end = num;

        long middle = (end + start) / 2;
        while(end - start > 1)
        {
            long temp = middle * middle;
            if (temp > num)
            {
                end = middle;
                middle = (end + start) / 2;
            }
            else if (temp < num)
            {
                start = middle;
                middle = (end + start) / 2;
            }
            else 
            {
                return true;
            }
        }
        return false;
    }
}

public class Q367_ValidPerfectSquareTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [16, true],       
        [14, false],       
        [1, true],      
        [5, false], 
        [2147483647, false], 
    ];
}

public class Q367_ValidPerfectSquareTests
{
    [Theory]
    [ClassData(typeof(Q367_ValidPerfectSquareTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q367_ValidPerfectSquare();
        var actual = sut.IsPerfectSquare(input);
        Assert.Equal(expected, actual);
    }
}
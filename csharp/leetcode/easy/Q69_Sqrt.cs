class Q69_SqrtTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [2, 1],
        [3, 1],
        [4, 2],
        [5, 2],
        [7, 2],
        [6, 2],
        [8, 2],
        [100, 10],
        [81, 9],
        [64, 8],
        [256, 16],
        [2147395600, 46340],
    ];
}

public class Q69_SqrtTests
{
    [Theory]
    [ClassData(typeof(Q69_SqrtTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q69_Sqrt();
        Assert.Equal(expected, sut.MySqrt_Binary(input));
    }
}

class Q69_Sqrt
{
    public int MySqrt(int x)
    {
        if (x == 0) return 0;
        if (x == 1) return 1;
        if (x == 2) return 1;

        for (int i = 2; i < x; i++)
        {
            uint z = (uint)(i * i);
            if (z > x)
            {
                return i - 1;
            }
        }
        return 0;
    }

    /*
    From NumberTheory, any positive integer i > 3 will have (i/2)^2 >= i  
    i: 1, i/2:0.5, i^2: 0.25
    i: 2, i/2:1, i^2: 1
    i: 3, i/2:1.5, i^2: 2.25
    i: 4, i/2:2, i^2: 4
    i: 5, i/2:2.5, i^2: 6.25
    */
    public void NumberTheory()
    {
        for (var i = 1; i < 100; i++)
        {
            double j = (double)i / 2;
        }
    }

    // Use binary search approach
    public int MySqrt_Binary(int x)
    {
        if (x == 0) return 0;
        else if (x == 1) return 1;

        var longX = (ulong)x;
        ulong start = 0;
        ulong end = longX;
        var steps = 0;
        while (end - start > 1)
        {
            steps++;
            decimal length = end + start;
            var middle = (ulong)length / 2;
            var middleSq = middle * middle;

            if (middleSq == longX)
            {
                return (int)middle;
            }
            else if (middleSq > longX)
            {
                // check if (middle-1)^2 < x
                var middleMinusOneSq = (middle - 1) * (middle - 1);
                if (middleMinusOneSq < longX)
                {
                    return (int)(middle - 1);
                }
                else
                {
                    end = middle;
                }
            }
            else
            {
                // middleSq < x
                // check if (middle+1)^2 > x
                var middlePlusOneSq = (middle + 1) * (middle + 1);
                if (middlePlusOneSq > longX)
                {
                    return (int)middle;
                }
                else
                {
                    start = middle;
                }
            }
        }
        return -1;
    }
}

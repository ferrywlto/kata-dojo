namespace dojo.leetcode;
public class Q69_SqrtTests
{
    [Theory]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 2)]
    [InlineData(7, 2)]
    [InlineData(6, 2)]
    [InlineData(8, 2)]
    [InlineData(100, 10)]
    [InlineData(81, 9)]
    [InlineData(64, 8)]
    [InlineData(256, 16)]
    [InlineData(2147395600, 46340)]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q69_Sqrt();
        Assert.Equal(expected, sut.MySqrt_Binary(input));

    }
}

public class Q69_Sqrt
{
    // Speed: 41ms (14.67%), Memory: 26.8MB (59.46%)
    public int MySqrt(int x)
    {
        // Console.WriteLine($"int.MaxValue: {int.MaxValue}, 2147395600");
        if (x == 0) return 0;
        if (x == 1) return 1;
        if (x == 2) return 1;

        for (int i = 2; i < x; i++)
        {
            // This line is very tricky for i = 46341, it will cause int overflow without exception and i will become 289398 if not cast to uint 
            uint z = (uint)(i * i);
            if (z > x)
            {
                // Console.WriteLine($"x:{x}, i:{i}, sq:{i*i}. {int.MaxValue-i*i}");
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
            // Console.WriteLine($"i: {i}, i/2:{j}, i^2: {j*j}");
        }
    }

    // Use binary search approach
    // Speed: 47ms (27.51%), Memory 26.3MB (98.77%)
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
            // Console.WriteLine($"start: {start}, end: {end}, middle: {middle}, x:{x}");

            if (middleSq == longX)
            {
                // Console.WriteLine($"steps: {steps}");
                return (int)middle;
            }
            else if (middleSq > longX)
            {
                // check if (middle-1)^2 < x
                var middleMinusOneSq = (middle - 1) * (middle - 1);
                if (middleMinusOneSq < longX)
                {
                    // Console.WriteLine($"steps: {steps}");
                    return (int)(middle - 1);
                }
                else
                {
                    end = middle;
                    // Console.WriteLine($"shrink right end: {end}");
                }
            }
            else
            { // middleSq < x
                // check if (middle+1)^2 > x
                var middlePlusOneSq = (middle + 1) * (middle + 1);
                if (middlePlusOneSq > longX)
                {
                    // Console.WriteLine($"steps: {steps}");
                    return (int)middle;
                }
                else
                {
                    start = middle;
                    // Console.WriteLine($"shrink left start: {start}");
                }
            }
        }
        return -1;
    }
}

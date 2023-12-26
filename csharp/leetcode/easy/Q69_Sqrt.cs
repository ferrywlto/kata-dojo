public class Q69_SqrtTests {
    [Theory]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(7, 2)]
    [InlineData(8, 2)]
    [InlineData(100, 10)]
    [InlineData(81, 9)]
    [InlineData(64, 8)]
    [InlineData(256, 16)]
    [InlineData(2147395600, 46340)]
    public void OfficialTestCases(int input, int expected) {
        var sut = new Q69_Sqrt();
        Assert.Equal(expected, sut.MySqrt(input));
    }
}

public class Q69_Sqrt {
    // Speed: 41ms (14.67%), Memory: 26.8MB (59.46%)
    public int MySqrt(int x) {
        Console.WriteLine($"int.MaxValue: {int.MaxValue}, 2147395600");
        if(x == 0) return 0;
        if(x == 1) return 1;
        if(x == 2) return 1;

        for (int i=2; i<x; i++) {
            // This line is very tricky for i = 46341, it will cause int overflow without exception and i will become 289398 if not cast to uint 
            uint z = (uint)(i*i);
            if (z > x) {
                Console.WriteLine($"x:{x}, i:{i}, sq:{i*i}. {int.MaxValue-i*i}");
                return i - 1;
            }
        }
        return 0;
    }
}


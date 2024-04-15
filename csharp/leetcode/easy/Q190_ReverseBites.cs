public class Q190_ReverseBits
{
    public uint reverseBits(uint n) 
    {
        var binaryString = Convert.ToString(n, 2).PadLeft(32, '0');;
        var reversedString = new string(binaryString.Reverse().ToArray());
        
        uint result = 0;
        for (int i = 0; i < reversedString!.Length; i++)
        {
            if (reversedString[i] == '1')
            {
                result += (uint)Math.Pow(2, reversedString.Length - 1 - i);
            }
        }

        return result;    
    }

    public uint reverseBits_BitWiseOps(uint n) 
    {
        uint result = 0;
        int bits = 32;

        while (bits-- > 0)
        {
            // Provided by Copilot, the idea is to shifting n leftward and shifting result rightward
            // n -> 
            // 1111111111111111111111111111110 1
            // <- result
            // 0000000000000000000000000000000 1 
            // 1. result << 1 left shift result once
            // 2. n & 1 means check if the right most bit is 1
            // 3. right most bit of result must be 0, OR with right most bit of n
            // 4. n = n right shift once 
            result = (result << 1) | (n & 1);
            n >>= 1;
        }

        return result;
    }
}

public class Q190_ReverseBitsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [43261596, 964176192],
        [4294967293, 3221225471],
    ];
}

public class Q190_ReverseBitsTests
{
    [Theory]
    [ClassData(typeof(Q190_ReverseBitsTestData))]
    public void OfficialTestCases(uint input, uint expected)
    {
        var sut = new Q190_ReverseBits();
        var actual = sut.reverseBits_BitWiseOps(input);
        Assert.Equal(expected, actual);
    }
}
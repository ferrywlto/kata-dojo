
namespace dojo.leetcode;

public class Q190_ReverseBitsTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [43261596, 964176192],
        [4294967293, 3221225471],
    ];
}

public class Q190_ReverseBitsTests(ITestOutputHelper output) : TestBase(output)
{
    [Theory]
    [ClassData(typeof(Q190_ReverseBitsTestData))]
    public void OfficialTestCases(uint input, uint expected)
    {
        var sut = new Q190_ReverseBits();
        var actual = sut.reverseBits(input);
        Assert.Equal(expected, actual);
    }
}

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
}


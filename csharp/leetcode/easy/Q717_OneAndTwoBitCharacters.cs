public class Q717_OneAndTwoBitCharacters
{
    public bool IsOneBitCharacter(int[] bits)
    {
        return Scan(bits, 0);
    }

    // TC: O(n)
    // SC: O(1)
    public bool Scan(int[] bits, int idx)
    {
        if (bits[idx] == 0)
        {
            if (idx == bits.Length - 1) return true;
            else return Scan(bits, idx + 1);
        }
        else
        {
            if (idx == bits.Length - 2) return false;
            else return Scan(bits, idx + 2);
        }
    }
}

public class Q717_OneAndTwoBitCharactersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1,0,0}, true],
        [new int[]{1,1,1,0}, false],
    ];
}

public class Q717_OneAndTwoBitCharactersTests
{
    [Theory]
    [ClassData(typeof(Q717_OneAndTwoBitCharactersTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q717_OneAndTwoBitCharacters();
        var actual = sut.IsOneBitCharacter(input);
        Assert.Equal(expected, actual);
    }
}

namespace dojo.leetcode;

public class Q461_HammingDistance
{
    // TC: O(num of bits in int) -> O(1), SC: O(1)
    public int HammingDistance(int x, int y)
    {
        // Hamming distance of bits is the number of bits different.
        // https://en.wikipedia.org/wiki/Hamming_distance
        // 111
        // 000 
        // xor = 111 -> 3 bits different -> Hamming Distance is 3
        // 101
        // 100
        // xor = 001 -> 1 bit different -> Hamming Distance is 1 
        // which is number of 1s after XOR literally
        var xor = x ^ y;
        var count = 0;
        while (xor != 0)
        {
            if((xor & 1) == 1) count++;
            xor >>= 1;
        } 
        return count;
    }
}

public class Q461_HammingDistanceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1, 4, 2],
        [3, 1, 1],
    ];
}

public class Q461_HammingDistanceTest
{
    [Theory]
    [ClassData(typeof(Q461_HammingDistanceTestData))]
    public void OfficerTestCase(int x, int y, int expected)
    {
        var sut = new Q461_HammingDistance();
        var actual = sut.HammingDistance(x, y);
        Assert.Equal(expected, actual);
    }
}
class Q1652_DefuseTheBomb
{
    // TC: O(n), where n is length of code
    // SC: O(n), where n is length of code to hold the result array
    public int[] Decrypt(int[] code, int k)
    {
        var result = new int[code.Length];
        for(var i=0; i<code.Length; i++)
        {
            var temp = 0;
            if(k > 0)
            {
                for(var j=0; j<k; j++)
                {
                    var idx = (i + 1 + j) % code.Length;
                    temp += code[idx];
                }
            }
            else if(k < 0)
            {
                for(var j=0; j>k; j--)
                {
                    var idx = (i - 1 + j) % code.Length;
                    // the tricky part here is to deal with negative modulus
                    if (idx < 0) idx += code.Length;
                    temp += code[idx];
                }                
            }
            result[i] = temp;
        }
        return result;
    }
}
class Q1652_DefuseTheBombTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {5,7,1,4}, 3, new int[] {12,10,16,13}],
        [new int[] {1,2,3,4}, 0, new int[] {0,0,0,0}],
        [new int[] {2,4,9,3}, -2, new int[] {12,5,6,13}],
    ];
}
public class Q1652_DefuseTheBombTests
{
    [Theory]
    [ClassData(typeof(Q1652_DefuseTheBombTestData))]
    public void OfficialTestCases(int[] input, int k, int[] expected)
    {
        var sut = new Q1652_DefuseTheBomb();
        var actual = sut.Decrypt(input, k);
        Assert.Equal(expected, actual);
    }
}
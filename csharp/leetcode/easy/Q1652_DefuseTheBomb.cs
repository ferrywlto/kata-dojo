class Q1652_DefuseTheBomb
{
    public int[] Decrypt(int[] code, int k)
    {
        return [];
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
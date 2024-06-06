
class Q1089_DuplicateZeros
{
    public void DuplicateZeros(int[] arr) 
    {

    }    
}
class Q1089_DuplicateZerosTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{1,0,2,3,0,4,5,0}, new int[]{1,0,0,2,3,0,0,4}],
        [new int[]{1,2,3}, new int[]{1,2,3}],
    ];
}
public class Q1089_DuplicateZerosTests
{
    [Theory]
    [ClassData(typeof(Q1089_DuplicateZerosTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1089_DuplicateZeros();
        sut.DuplicateZeros(input);
        Assert.Equal(input, expected);
    }
}
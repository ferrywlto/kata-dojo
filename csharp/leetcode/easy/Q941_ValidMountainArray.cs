
class Q941_ValidMountainArray
{
        public bool ValidMountainArray(int[] arr) {
        return false;   
    }
}

class Q941_ValidMountainArrayTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{2,1}, false],
        [new int[]{3,5,5}, false],
        [new int[]{0,3,2,1}, true],
        [new int[]{0,3,2,1,1}, false],
        [new int[]{0,3,2,1,3}, false],
    ];
}

public class Q941_ValidMountainArrayTests
{
    [Theory]
    [ClassData(typeof(Q941_ValidMountainArrayTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q941_ValidMountainArray();
        var actual = sut.ValidMountainArray(input);
        Assert.Equal(expected, actual);
    }
}
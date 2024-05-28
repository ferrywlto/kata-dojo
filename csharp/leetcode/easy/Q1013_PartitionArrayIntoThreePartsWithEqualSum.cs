
class Q1013_PartitionArrayIntoThreePartsWithEqualSum
{
        public bool CanThreePartsEqualSum(int[] arr) {
        return false;   
    }
}

class Q1013_PartitionArrayIntoThreePartsWithEqualSumTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {0,2,1,-6,6,-7,9,1,2,0,1}, true],
        [new int[] {0,2,1,-6,6,7,9,-1,2,0,1}, false],
        [new int[] {3,3,6,5,-2,2,5,1,-9,4}, true],
    ];
}

public class Q1013_PartitionArrayIntoThreePartsWithEqualSumTests
{
    [Theory]
    [ClassData(typeof(Q1013_PartitionArrayIntoThreePartsWithEqualSumTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1013_PartitionArrayIntoThreePartsWithEqualSum();
        var actual = sut.CanThreePartsEqualSum(input);
        Assert.Equal(expected, actual);
    }
}

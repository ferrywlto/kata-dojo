namespace dojo.leetcode;

public class Q283_MoveZeros
{
    public void MoveZeroes(int[] nums)
    {
        if (nums.Length <= 1) return;
        var haveZero = false;
        var zeroIdx = 0;
        var zeroPassed = 0;
        for(var i=0; i<nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                if(haveZero) 
                {
                    zeroPassed++;
                }
                else 
                {
                    zeroIdx = i;
                    haveZero = true;
                }
            }
            else if(haveZero)
            {
                nums[zeroIdx] = nums[i];
                nums[i] = 0;
                zeroIdx = i-zeroPassed;
            }
        }
    }
}

public class Q283_MoveZerosTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new int[]{0,1,0,3,12}, new int[]{1,3,12,0,0}],
        [new int[]{0}, new int[]{0}],
        [new int[]{2,1}, new int[]{2,1}],
        [new int[]{1,0,1}, new int[]{1,1,0}],
        [new int[]{4,2,4,0,0,3,0,5,1,0}, new int[]{4,2,4,3,5,1,0,0,0,0}],
    ];
}

public class Q283_MoveZerosTests
{
    [Theory]
    [ClassData(typeof(Q283_MoveZerosTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q283_MoveZeros();
        sut.MoveZeroes(input);
        Assert.True(Enumerable.SequenceEqual(expected, input));
    }
}
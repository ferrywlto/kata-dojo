public class Q2899_LastVisitedIntegers
{
    public IList<int> LastVisitedIntegers(int[] nums) {
     return [];   
    }    
    public static TheoryData<int[], List<int>> TestData => new()
    {
        {[1,2,-1,-1,-1], [2,1,-1]},
        {[1,-1,2,-1,-1], [1,2,1]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, List<int> expected)
    {
        var actual = LastVisitedIntegers(input);
        Assert.Equal(expected, actual);
    }
}
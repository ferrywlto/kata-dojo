using dojo.leetcode;

public class Q169_MajorityElementTestData : TestDataBase
{
    protected override List<object[]> Data() =>
    [
        [new int[] { 3, 2, 3 }, 3],
        [new int[] { 2, 2, 1, 1, 1, 2, 2}, 2]
    ];
}
public class Q169_MajorityElementTests(ITestOutputHelper output) : TestBase(output) 
{
    [Theory]
    [ClassData(typeof(Q169_MajorityElementTestData))]
    public void OfficialTestCases(int[] nums, int expected) 
    {
        var sut = new Q169_MajorityElement();
        var res = sut.MajorityElement(nums);

        Assert.Equal(expected, res);
    }
}

public class Q169_MajorityElement
{
    public int MajorityElement(int[] nums)
    {
        return 0;
    }
}
public class Q136_SingleNumberTests 
{
    [Theory]
    [InlineData(new int[] {2,2,1}, 1)]
    [InlineData(new int[] {4,1,2,1,2}, 4)]
    [InlineData(new int[] {1}, 1)]
    public void OfficialTestCases(int[] input, int expected) {
        var sut = new Q136_SingleNumber();
        var actual = sut.SingleNumber(input);
        Assert.Equal(expected, actual);
     }
}
public class Q136_SingleNumber {
    public int SingleNumber(int[] nums) 
    {
        return 0;    
    }
}

namespace dojo.leetcode;

public class Q728_SelfDividingNumbers
{
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        var result = new List<int>();

        for (var i = left; i <= right; i++)
        {
            if (i < 10) result.Add(i);
            else
            {
                var n = i;
                var selfDividing = true;
                while (n > 0 && selfDividing)
                {
                    var digit = n % 10;
                    if (digit == 0 || i % digit != 0) selfDividing = false;
                    else n /= 10;
                }
                
                if (selfDividing) result.Add(i);
            }
        }
        return result;
    }
}

public class Q728_SelfDividingNumbersTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1,22, new int[]{1,2,3,4,5,6,7,8,9,11,12,15,22}],
        [47,85, new int[]{48,55,66,77}],
    ];
}

public class Q728_SelfDividingNumbersTests
{
    [Theory]
    [ClassData(typeof(Q728_SelfDividingNumbersTestData))]
    public void OfficialTestCases(int left, int right, int[] expected)
    {
        var sut = new Q728_SelfDividingNumbers();
        var actual = sut.SelfDividingNumbers(left, right);
        Assert.Equal(expected, actual);
    }
}
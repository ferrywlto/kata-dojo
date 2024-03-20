
namespace dojo.leetcode;

public class Q728_SelfDividingNumbers
{
    public IList<int> SelfDividingNumbers(int left, int right) 
    {
        var result = new List<int>();
        
        for(var i=left; i<=right; i++)
        {
            if (i < 10) result.Add(i);
            else
            {
                var str = i.ToString();
                var selfDividing = true;
                foreach(var c in str) 
                {
                    var x = c - 48;
                    if (x == 0 || i % x != 0)
                    {
                        selfDividing = false;
                        break;
                    }
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

namespace dojo.leetcode;

public class Q507_PerfectNumber
{
    readonly HashSet<int> cache = [1];
    // TC: O(n), SC: O(n)
    public bool CheckPerfectNumber(int num)
    {
        if (num <= 1) return false;
        for(var i=2; i<num/2; i++)
        {
            if(!cache.Contains(i) && num % i == 0)
            {
                var temp = num/i;
                cache.Add(i);
                cache.Add(temp);
            }
        }
        return cache.Sum(x => x) == num;
    }
}

public class Q507_PerfectNumberTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [28, true],
        [6, true],
        [496, true],
        [8128, true],
        [1, false],
        [2, false],
        [3, false],
        [4, false],
        [5, false],
        [7, false],
        [8, false],
        [9, false],
        [10, false],
        [11, false],
        [12, false],
        [13, false],
        [14, false],
        [15, false],
        [16, false],
        [17, false],
        [18, false],
        [19, false],
        [20, false],
        [21, false],
        [22, false],
        [23, false],
        [24, false],
        [25, false],
        [26, false],
        [27, false],
        [29, false],
        [30, false],
        [31, false],
        [32, false],
        [33, false],
        [34, false],
        [35, false],
        [36, false],
        [37, false],
        [38, false],
        [39, false],
        [40, false],
        [41, false],
        [42, false],
        [43, false],
        [44, false],
        [45, false],
        [46, false],
        [47, false],
        [48, false],
    ];
}

public class Q507_PerfectNumberTests
{
    [Theory]
    [ClassData(typeof(Q507_PerfectNumberTestData))]
    public void Test_CheckPerfectNumber(int num, bool expected)
    {
        var sut = new Q507_PerfectNumber();
        var actual = sut.CheckPerfectNumber(num);
        Assert.Equal(expected, actual);
    }
}
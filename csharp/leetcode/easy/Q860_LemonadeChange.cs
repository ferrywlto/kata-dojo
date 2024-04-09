namespace dojo.leetcode;

public class Q860_LemonadeChange
{
    // TC: O(n), n is length of bills
    // SC: O(1), the dictionry size is fixed
    public bool LemonadeChange(int[] bills) 
    {
        var cashier = new Dictionary<int, int>()
        {
            {5,0},
            {10,0},
        };

        for(var i=0; i<bills.Length; i++)
        {
            if(bills[i] == 5)
            {
                cashier[5]++;
            } 
            else if(bills[i] == 10 && cashier[5] > 0)
            {
                cashier[10]++;
                cashier[5]--;
            }
            else
            {
                if (cashier[10] > 0 && cashier[5] > 0)
                {
                    cashier[10]--;
                    cashier[5]--;
                }
                else if (cashier[5] > 2)
                {
                    cashier[5] -= 3;
                }
                else return false;
            }
        }
        return true;    
    }
}

public class Q860_LemonadeChangeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {5,5,5,10,20}, true],
        [new int[] {5,5,10,10,20}, false],
    ];
}

public class Q860_LemonadeChangeTests
{
    [Theory]
    [ClassData(typeof(Q860_LemonadeChangeTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q860_LemonadeChange();
        var actual = sut.LemonadeChange(input);
        Assert.Equal(expected, actual);
    }
}
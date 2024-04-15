public class Q599_MinIndexSumOfTwoList
{
    // TC: O(n+m)
    // SC: O(n+m)
    public string[] FindRestaurant(string[] list1, string[] list2) 
    {
        var dict = new Dictionary<string, int>();
        for(var i=0; i<list1.Length; i++)
        {
            dict.Add(list1[i], i);
        }
        
        var minSum = int.MaxValue;
        List<string> result = [];
        for(var j=0; j<list2.Length; j++)
        {
            if(dict.TryGetValue(list2[j], out int value))
            {
                var sum = value + j;
                if(sum < minSum)
                {
                    minSum = value + j;
                    result = [list2[j]];
                }
                else if(sum == minSum)
                {
                    result.Add(list2[j]);
                }
            }
        }
        return result.ToArray();
    }
}

public class Q599_MinIndexSumOfTwoListTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new string[]{"Shogun","Tapioca Express","Burger King","KFC"}, 
            new string[]{"Piatti","The Grill at Torrey Pines","Hungry Hunter Steakhouse","Shogun"},
            new string[]{"Shogun"},
        ],
        [
            new string[]{"Shogun","Tapioca Express","Burger King","KFC"}, 
            new string[]{"KFC","Shogun","Burger King"},
            new string[]{"Shogun"},
        ],
        [
            new string[]{"happy","sad","good"}, 
            new string[]{"sad","happy","good"},
            new string[]{"sad","happy"},
        ],
    ];
}

public class Q599_MinIndexSumOfTwoListTests
{
    [Theory]
    [ClassData(typeof(Q599_MinIndexSumOfTwoListTestData))]
    public void OfficialTestCases(string[] list1, string[] list2, string[] expected)
    {
        var sut = new Q599_MinIndexSumOfTwoList();
        var actual = sut.FindRestaurant(list1, list2);

        Array.Sort(expected);
        Array.Sort(actual);
        Assert.Equal(expected, actual);
    }
}
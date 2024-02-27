namespace dojo.leetcode;

public class Q599_MinIndexSumOfTwoList
{
    // Use O(n+m) approach
    public string[] FindRestaurant(string[] list1, string[] list2) 
    {
        var dict = new Dictionary<string, int>();
        for(var i=0; i<list1.Length; i++)
        {
            dict.Add(list1[i], i);
        }
        var result = new Dictionary<string, int>();
        for(var j=0; j<list2.Length; j++)
        {
            if(dict.TryGetValue(list2[j], out int value))
            {
                result.Add(list2[j], value + j);
            }
        }
        var minSum = result.Min(x => x.Value);
        return result
            .Where(x => x.Value == minSum)
            .Select(x => x.Key)
            .ToArray();
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
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
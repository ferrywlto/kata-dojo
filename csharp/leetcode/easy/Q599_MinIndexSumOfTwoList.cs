
namespace dojo.leetcode;

public class Q599_MinIndexSumOfTwoList
{
    public string[] FindRestaurant(string[] list1, string[] list2) 
    {
        return [];
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
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}
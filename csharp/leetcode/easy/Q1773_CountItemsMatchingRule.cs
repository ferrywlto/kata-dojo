class Q1773_CountItemsMatchingRule
{
    // TC: O(n), where n is length of items
    // SC: O(1), space used is fixed
    private readonly string[] keys = ["type", "color", "name"];
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {
        var compareIdx = Array.IndexOf(keys, ruleKey);
        var result = 0;
        foreach (var item in items)
        {
            if (item[compareIdx] == ruleValue) result++;
        }
        return result;
    }
}
class Q1773_CountItemsMatchingRuleTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new string[][] {
                ["phone","blue","pixel"],
                ["computer","silver","lenovo"],
                ["phone","gold","iphone"]
            }, "color", "silver", 1
        ],
        [
            new string[][] {
                ["phone","blue","pixel"],
                ["computer","silver","phone"],
                ["phone","gold","iphone"]
            }, "type", "phone", 2
        ]
    ];
}
public class Q1773_CountItemsMatchingRuleTests
{
    [Theory]
    [ClassData(typeof(Q1773_CountItemsMatchingRuleTestData))]
    public void OfficialTestCases(string[][] input, string key, string value, int expected)
    {
        var sut = new Q1773_CountItemsMatchingRule();
        var actual = sut.CountMatches(input, key, value);
        Assert.Equal(expected, actual);
    }
}
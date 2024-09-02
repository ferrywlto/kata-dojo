
class Q1773_CountItemsMatchingRule
{
    public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
    {
        return 0;
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
            }, "color", "silver"
        ],
        [
            new string[][] {
                ["phone","blue","pixel"],
                ["computer","silver","phone"],
                ["phone","gold","iphone"]
            }, "type", "phone"
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